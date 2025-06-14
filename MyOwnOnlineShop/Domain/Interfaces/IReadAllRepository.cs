namespace Domain.Interfaces;
public interface IReadAllRepository<T> : IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
}
