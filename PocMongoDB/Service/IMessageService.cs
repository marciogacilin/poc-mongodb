using PocMongoDB.Entities;

namespace PocMongoDB.Service;

public interface IMessageService
{
    Task Create(Message message);
    Task<IEnumerable<Message>> GetByCompanyId(long companyId);
}
