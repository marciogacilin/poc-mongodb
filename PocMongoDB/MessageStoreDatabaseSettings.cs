namespace PocMongoDB;

public class MessageStoreDatabaseSettings
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }

    public string MessagesCollectionName { get; set; }
}
