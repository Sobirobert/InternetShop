using Application.Dto.ProductDtoFolder;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Queries.ProductQueries;

public class GetProductByIdHandler(IProductService productService, IMapper mapper) : IRequestHandler<GetProductByIdQuery, ProductDto>
{   
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(request.ProductId);
        if (product == null)
        {
            throw new NotFoundException($"Product with id {request.ProductId} does not exist.");
        }

        return product;
    }
}
