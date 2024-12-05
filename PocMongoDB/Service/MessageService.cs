using PocMongoDB.Entities;
using PocMongoDB.Repository;

namespace PocMongoDB.Service;

public class MessageService(IMessageRepository messageRepository) : IMessageService
{
    public async Task Create(Message message)
        => await messageRepository.Create(message);

    public async Task<IEnumerable<Message>> GetByCompanyId(long companyId)
        => await messageRepository.GetAllByCompanyId(companyId);
}
