using Microsoft.AspNetCore.Mvc;
using PocMongoDB;
using PocMongoDB.Entities;
using PocMongoDB.Repository;
using PocMongoDB.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration(static delegate (HostBuilderContext context, IConfigurationBuilder config)
{
    if (context.HostingEnvironment.IsDevelopment())
        config.AddUserSecrets<Program>();
    else
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MessageStoreDatabaseSettings>(builder.Configuration.GetSection("MessageStoreDatabase"));
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IMessageService, MessageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/message", async ([FromBody] Message message, IMessageService messageService) =>
{
    await messageService.Create(message);
    return Results.Created();
})
.WithTags("Messages")
.WithOpenApi();

app.MapGet("/message/{companyId}", async (long companyId, IMessageService messageService) =>
{
    var result = await messageService.GetByCompanyId(companyId);
    return Results.Ok(result);
})
.WithTags("Messages")
.WithOpenApi();

app.Run();
