using Application.Dto.ProductDtoFolder;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace WebAPI.Functions.Queries.ProductQueries;

public class GetProductByIdHandler(IProductService productService, IMapper mapper) : IRequestHandler<GetProductByIdQuery, ProductDto>
{   
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(request.ProductId);
        return product;
    }
}
