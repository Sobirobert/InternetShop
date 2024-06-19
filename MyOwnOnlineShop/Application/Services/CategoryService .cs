using Application.Dto;
using Application.Dto.Category;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Category;
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
    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }
    public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto newcategory)
    {
        var category = _mapper.Map<Category>(newcategory);
        var result = await _categoryRepository.AddAsync(category);
        return _mapper.Map<CategoryDto>(result);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto categoryUpdate)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(categoryUpdate.Id);
        var category = _mapper.Map(categoryUpdate, existingCategory);
        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        await _categoryRepository.DeleteAsync(category);
    }
}