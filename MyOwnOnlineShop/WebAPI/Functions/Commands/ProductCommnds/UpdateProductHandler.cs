using Application.Interfaces;
using MediatR;

namespace WebAPI.Functions.Commands.ProductCommnds;

public class UpdateProductHandler(IProductService productService) : IRequestHandler<UpdateProductCommand>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await productService.UpdateProduct(request.UpdateProductDto);
        return Unit.Value;
    }
}
