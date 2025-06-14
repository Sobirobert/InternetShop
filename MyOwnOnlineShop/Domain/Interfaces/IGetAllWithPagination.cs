namespace Domain.Interfaces;
public interface IGetAllWithPagination<T> : IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
}
