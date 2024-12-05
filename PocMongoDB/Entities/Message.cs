using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PocMongoDB.Entities;

public class Message
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public long CompanyId { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string TextMessage { get; set; }
}
