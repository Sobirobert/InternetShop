using Application.Interfaces;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Commands.ProductCommnds;

public class DeleteProductHandler(IProductService productService) : IRequestHandler<DeleteProductCommand>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(request.Id);
        if (product == null)
        {
            throw new NotFoundException($"Product with id {request.Id} does not exist.");
        }

        await productService.DeleteProduct(request.Id);
        return Unit.Value;
    }
}
