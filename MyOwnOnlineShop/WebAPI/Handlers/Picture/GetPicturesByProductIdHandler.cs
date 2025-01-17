using Application.Dto;
using Application.Interfaces;
using MediatR;
using WebAPI.Queries.Picture;

namespace WebAPI.Handlers.Picture;

public class GetProductByIdHandler : IRequestHandler<GetPicrtureByProductIdQuery, IEnumerable<PictureDto>>
{
    private readonly IPictureService _pictureService;
    public GetProductByIdHandler(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }
    public async Task<IEnumerable<PictureDto>> Handle(GetPicrtureByProductIdQuery request, CancellationToken cancellationToken)
    {
        var pictures = await _pictureService.GetPicturesByProductId(request.ProductId);
        return pictures == null ? null : pictures;
    }
}
