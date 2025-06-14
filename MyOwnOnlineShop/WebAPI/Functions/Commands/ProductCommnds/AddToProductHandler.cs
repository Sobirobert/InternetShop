using Application.Dto.ProductDtoFolder;
using Application.Interfaces;
using MediatR;

namespace WebAPI.Functions.Commands.ProductCommnds;

public class AddToProductHandler(IProductService productService) : IRequestHandler<AddToProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(AddToProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productService.AddNewProduct(request.ProductDto);
        return product;
    }
}
