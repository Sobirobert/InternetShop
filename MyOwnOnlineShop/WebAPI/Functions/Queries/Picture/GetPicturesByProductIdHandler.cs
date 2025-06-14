using Application.Dto;
using Application.Interfaces;
using MediatR;

namespace WebAPI.Functions.Queries.Picture;

public class GetProductByIdHandler(IPictureService pictureService) : IRequestHandler<GetPicrtureByProductIdQuery, IEnumerable<PictureDto>>
{
    public async Task<IEnumerable<PictureDto>> Handle(GetPicrtureByProductIdQuery request, CancellationToken cancellationToken)
    {
        var pictures = await pictureService.GetPicturesByProductId(request.ProductId);
        return pictures == null ? null : pictures;
    }
}
