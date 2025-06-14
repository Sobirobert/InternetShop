using Application.Dto.ProductDtoFolder;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Queries.ProductQueries;
public class GetAllProductQuery(int PageNumber, int PageSize, string SortField, bool Ascending, string filterBy) : IRequest<PagedResponse<IEnumerable<ProductDto>>>
{
    public int PageNumber { get; } = PageNumber;
    public int PageSize { get; } = PageSize;
    public string SortField { get; } = SortField;
    public bool Ascending { get; } = Ascending;
    public string FilterBy { get; } = filterBy;
}
