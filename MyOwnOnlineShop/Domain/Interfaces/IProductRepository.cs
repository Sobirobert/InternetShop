using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize/*, string sortField, bool ascending, string filterBy*/);

    Task<int> GetAllCountAsync(/*string filterBy*/);

    Task<Product> GetByIdAsync(int id);

    Task<Product> AddAsync(Product product);

    Task UpdateAsync(Product product);

    Task DeleteAsync(Product product);
}