using Application.Dto.ProductDtoFolder;
using Application.Interfaces;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Commands.ProductCommnds;

public class AddToProductHandler(IProductService productService) : IRequestHandler<AddToProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(AddToProductCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new NullRequestExeption($"Product with name '{request.ProductDto}' isn't exists.");
        }
        var product = await productService.AddNewProduct(request.ProductDto);
        return product;
    }
}
