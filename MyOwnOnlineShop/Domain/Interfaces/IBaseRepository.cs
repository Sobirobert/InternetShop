
namespace Domain.Interfaces;

public interface IBaseRepository<T> : IRepository<T> where T : class
{
    Task Add(T entity);
    Task<T> Get(int id);
    Task Delete(T entity);
}
