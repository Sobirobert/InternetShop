using Application.Dto.CategoryDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;
public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
    {
        var categories = await categoryRepository.GetAll();
        return mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<int> GetProductsCount(int id)
    {
        var countProducts = await categoryRepository.GetProductsCountInCategory(id);
        return countProducts;
    }

    public async Task<CategoryDto> GetCategoryById(int id)
    {
        var category = await categoryRepository.GetById(id);
        return mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> GetCategoryByName(string name)
    {
        var category = await categoryRepository.GetByName(name);
        return mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateCategory(CreateCategoryDto newcategory)
    {
        var category = mapper.Map<Category>(newcategory);
        var result = await categoryRepository.Add(category);
        return mapper.Map<CategoryDto>(result);
    }

    public async Task UpdateCategory(UpdateCategoryDto categoryUpdate)
    {
        var existingCategory = await categoryRepository.GetById(categoryUpdate.Id);
        if (existingCategory != null)
        {
        }
        var category = mapper.Map(categoryUpdate, existingCategory);
        await categoryRepository.Update(category);
    }

    public async Task DeleteCategory(int id)
    {
        var category = await categoryRepository.GetById(id);
        await categoryRepository.Delete(category);
    }
}