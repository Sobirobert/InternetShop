using Application.Dto.ProductDtoFolder;
using MediatR;

namespace WebAPI.Functions.Commands.ProductCommnds;

public class UpdateProductCommand(UpdateProductDto updateProductDto) : IRequest
{
    public UpdateProductDto UpdateProductDto { get; } = updateProductDto;
}
