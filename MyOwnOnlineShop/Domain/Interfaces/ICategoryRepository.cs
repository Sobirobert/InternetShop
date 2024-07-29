using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();

        Task<int> GetProductsCountInCategory(int id);

        Task<Category> GetById(int id);

        Task<Category> GetByName(string name);

        Task<Category> Add(Category category);

        Task Update(Category category);

        Task Delete(Category category);
    }
}