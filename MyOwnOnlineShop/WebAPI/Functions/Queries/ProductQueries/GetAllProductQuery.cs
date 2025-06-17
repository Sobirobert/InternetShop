using Application.Dto.ProductDtoFolder;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Queries.ProductQueries;
public record GetAllProductQuery(int PageNumber, int PageSize, string SortField, bool Ascending, string FilterBy) : IRequest<PagedResponse<IEnumerable<ProductDto>>>;