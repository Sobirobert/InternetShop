using Application.Dto.ProductDtoFolder;
using MediatR;

namespace WebAPI.Functions.Queries.ProductQueries;

public record GetProductByIdQuery(int ProductId) : IRequest<ProductDto>;