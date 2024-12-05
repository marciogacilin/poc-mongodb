using PocMongoDB.Entities;

namespace PocMongoDB.Repository;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> GetAllByCompanyId(long companyId);
    Task<Message> GetById(string id);
    Task Create(Message message);
    Task Update(string id, Message message);
    Task Delete(string id);
}
