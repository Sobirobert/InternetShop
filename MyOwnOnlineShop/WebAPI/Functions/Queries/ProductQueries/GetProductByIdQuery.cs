using Application.Dto.ProductDtoFolder;
using Azure.Core;
using MediatR;

namespace WebAPI.Functions.Queries.ProductQueries;

public class GetProductByIdQuery(int productId) : IRequest<ProductDto>
{
    public int ProductId { get; } = productId;
}
