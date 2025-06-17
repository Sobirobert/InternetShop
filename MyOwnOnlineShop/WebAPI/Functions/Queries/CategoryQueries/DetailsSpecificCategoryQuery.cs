using Application.Dto.CategoryDto;
using MediatR;

namespace WebAPI.Functions.Queries.CategoryQueries;

public record DetailsSpecificCategoryQuery(int CategoryId) : IRequest<CategoryDto>;
