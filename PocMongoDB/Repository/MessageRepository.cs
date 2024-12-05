using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PocMongoDB.Entities;

namespace PocMongoDB.Repository;

public class MessageRepository : IMessageRepository
{
    private readonly IMongoCollection<Message> _messagesCollection;

    public MessageRepository(IOptions<MessageStoreDatabaseSettings> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
        _messagesCollection = mongoDatabase.GetCollection<Message>(options.Value.MessagesCollectionName);
    }

    public async Task Create(Message message)
        => await _messagesCollection.InsertOneAsync(message);

    public async Task Delete(string id)
        => await _messagesCollection.DeleteOneAsync(x => x.Id == id);

    public async Task<IEnumerable<Message>> GetAllByCompanyId(long companyId)
        => await _messagesCollection.Find(i => i.CompanyId == companyId).ToListAsync();

    public async Task<Message> GetById(string id)
        => await _messagesCollection.Find(i => i.Id == id).FirstOrDefaultAsync();

    public async Task Update(string id, Message message)
        => await _messagesCollection.ReplaceOneAsync(id, message);
}
