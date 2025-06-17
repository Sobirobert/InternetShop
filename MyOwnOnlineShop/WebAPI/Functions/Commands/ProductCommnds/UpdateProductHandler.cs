using Application.Interfaces;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Commands.ProductCommnds;

public class UpdateProductHandler(IProductService productService) : IRequestHandler<UpdateProductCommand>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await productService.GetProductById(request.UpdateProductDto.Id);
        if (existingProduct == null)
        {
            throw new NotFoundException($"Product with id {request.UpdateProductDto.Id} does not exist.");
        }

        var productWithSameName = await productService.GetProductById(request.UpdateProductDto.Id);
        if (productWithSameName != null && productWithSameName.Id != request.UpdateProductDto.Id)
        {
            throw new ConflictException($"Another product with name '{request.UpdateProductDto.Id}' already exists.");
        }

        await productService.UpdateProduct(request.UpdateProductDto);
        return Unit.Value;
    }
}
