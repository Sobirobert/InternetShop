using Application.Dto.CategoryDto;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace WebAPI.Functions.Queries.CategoryQueries;

public class DetailsSpecificCategoryHandler(ICategoryService categoryService, IMapper mapper) : IRequestHandler<DetailsSpecificCategoryQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(DetailsSpecificCategoryQuery request, CancellationToken cancellationToken)
    {
        if (request.CategoryId <= 0)
        {
            throw new BadRequestException("Category ID must be greater than 0.");
        }

        var category = await categoryService.GetCategoryById(request.CategoryId);

        if (category == null)
        {
            throw new NotFoundException($"Category with id {request.CategoryId} does not exist.");
        }

        var totalRecords = await categoryService.GetProductsCount(request.CategoryId);
        var categoryDto = mapper.Map<CategoryDto>(category);

        return categoryDto with { TotalRecords = totalRecords };
    }
}
