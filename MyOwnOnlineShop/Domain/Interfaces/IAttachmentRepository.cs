namespace Domain.Interfaces;
public interface IAttachmentRepository<T> : IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetByProductId(int productId);
}