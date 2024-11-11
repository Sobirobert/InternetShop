using Application.Dto.CategoryDto;

namespace Application.Interfaces;
public interface ICategoryService
{
    Task<int> GetProductsCount(int id);

    Task<IEnumerable<CategoryDto>> GetAllCategories();

    Task<CategoryDto> GetCategoryById(int id);

    Task<CategoryDto> GetCategoryByName(string name);

    Task<CategoryDto> CreateCategory(CreateCategoryDto category);

    Task UpdateCategory(UpdateCategoryDto category);

    Task DeleteCategory(int id);
}