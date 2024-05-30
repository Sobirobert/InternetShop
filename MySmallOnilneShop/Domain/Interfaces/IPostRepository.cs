using Domain.Entities;

namespace Domain.Interfaces;

public interface IPostRepository
{
    Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);

    Task<int> GetAllCountAsync(string filterBy);

    Task<Product> GetByIdAsync(int id);

    Task<Product> AddAsync(Product post);

    Task UpdateAsync(Product post);

    Task DeleteAsync(Product post);
}
