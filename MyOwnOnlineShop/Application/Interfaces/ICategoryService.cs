﻿using Application.Dto.Category;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

    Task<CategoryDto> GetCategoryByIdAsync(int id);

    Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto category);

    Task UpdateCategoryAsync(UpdateCategoryDto category);

    Task DeleteCategoryAsync(int id);
}