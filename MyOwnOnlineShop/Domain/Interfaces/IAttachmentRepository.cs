using Domain.Entities;

namespace Domain.Interfaces;

public interface IAttachmentRepository
{
    Task<IEnumerable<Attachment>> GetByProductId(int productId);

    Task<Attachment> GetById(int id);

    Task<Attachment> Add(Attachment attachment);

    Task Delete(Attachment attachment);
}