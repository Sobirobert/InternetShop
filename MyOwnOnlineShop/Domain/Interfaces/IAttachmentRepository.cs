using Domain.Entities;

namespace Domain.Interfaces;

public interface IAttachmentRepository
{
    Task<IEnumerable<Attachment>> GetByProductIdAsync(int productId);

    Task<Attachment> GetByIdAsync(int id);

    Task<Attachment> AddAsync(Attachment attachment);

    Task DeleteAsync(Attachment attachment);
}