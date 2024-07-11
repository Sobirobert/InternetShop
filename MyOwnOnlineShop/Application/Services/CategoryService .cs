using Application.Dto.CategoryDto;
using Application.Interfaces;
using AutoMapper;
using Azure;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<int> GetProductsCount(int id)
    {
        var countProducts = await _categoryRepository.GetProductsCountInCategory(id);
        return countProducts;
    }

    public async Task<CategoryDto> GetCategoryById(int id)
    {
        var category = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> GetCategoryByName(string name)
    {
        var category = await _categoryRepository.GetByName(name);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateCategory(CreateCategoryDto newcategory)
    {
        var category = _mapper.Map<Category>(newcategory);
        var result = await _categoryRepository.Add(category);
        return _mapper.Map<CategoryDto>(result);
    }

    public async Task UpdateCategory(UpdateCategoryDto categoryUpdate)
    {
        var existingCategory = await _categoryRepository.GetById(categoryUpdate.Id);
        if (existingCategory != null)
        {
            
        }
        var category = _mapper.Map(categoryUpdate, existingCategory);
        await _categoryRepository.Update(category);
    }

    public async Task DeleteCategory(int id)
    {
        var category = await _categoryRepository.GetById(id);
        await _categoryRepository.Delete(category);
    }
}