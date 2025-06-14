using Application.Dto;
using Application.Dto.ProductDtoFolder;
using MediatR;

namespace WebAPI.Functions.Commands.ProductCommnds;

public class AddToProductCommand(CreateProductDto productDto) : IRequest<ProductDto>
{
    public CreateProductDto ProductDto { get; } = productDto;
}
