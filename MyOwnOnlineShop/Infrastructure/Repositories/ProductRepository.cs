using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    //private readonly BloggerContext _context;

    public Task<Product> AddAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetAllCountAsync(string filterBy)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
}