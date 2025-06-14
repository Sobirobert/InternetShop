namespace Domain.Interfaces;
public interface IUpdateRepository<T> : IRepository<T> where T : class
{
    Task UpdateAsync(T entity);
}
