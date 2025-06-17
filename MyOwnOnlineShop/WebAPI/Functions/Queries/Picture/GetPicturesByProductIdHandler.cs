using Application.Dto;
using Application.Interfaces;
using Application.Services;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Queries.Picture;

public class GetProductByIdHandler(IPictureService pictureService, IProductService productService) : IRequestHandler<GetPicrtureByProductIdQuery, IEnumerable<PictureDto>>
{
    public async Task<IEnumerable<PictureDto>> Handle(GetPicrtureByProductIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(request.ProductId);
        if (product == null)
        {
            throw new NotFoundException($"Product with id {request.ProductId} does not exist.");
        }

        var pictures = await pictureService.GetPicturesByProductId(request.ProductId);
        return pictures ?? Enumerable.Empty<PictureDto>();
    }
}
