using Application.Interfaces;
using MediatR;

namespace WebAPI.Functions.Commands.ProductCommnds;

public class DeleteProductHandler(IProductService productService) : IRequestHandler<DeleteProductCommand>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await productService.DeleteProduct(request.Id);
        return Unit.Value;
    }
}
