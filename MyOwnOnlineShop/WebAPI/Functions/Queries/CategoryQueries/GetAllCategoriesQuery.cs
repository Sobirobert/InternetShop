using Application.Dto.CategoryDto;
using MediatR;

namespace WebAPI.Functions.Queries.CategoryQueries;

public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;
