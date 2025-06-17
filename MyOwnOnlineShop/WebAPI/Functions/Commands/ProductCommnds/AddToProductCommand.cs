using Application.Dto.ProductDtoFolder;
using MediatR;

namespace WebAPI.Functions.Commands.ProductCommnds;

public record AddToProductCommand(CreateProductDto ProductDto) : IRequest<ProductDto>;