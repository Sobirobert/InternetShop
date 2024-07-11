using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);

    Task<int> GetAllCount(string filterBy);

    Task<Product> GetById(int id);

    Task<IEnumerable<Product>> ProductOfTheWeek();

    Task<Product> Add(Product product);

    Task Update(Product product);

    Task Delete(Product product);
}