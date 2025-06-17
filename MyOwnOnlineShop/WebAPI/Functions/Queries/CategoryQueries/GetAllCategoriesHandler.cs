using Application.Dto.CategoryDto;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Queries.CategoryQueries;

public class GetAllCategoriesHandler(ICategoryService categoryService, IMapper mapper) : ControllerBase, IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryService.GetAllCategories();

        if (categories == null || !categories.Any())
        {
            throw new NotFoundException("No categories found.");
        }

        return mapper.Map<IEnumerable<CategoryDto>>(categories);
    }
}
