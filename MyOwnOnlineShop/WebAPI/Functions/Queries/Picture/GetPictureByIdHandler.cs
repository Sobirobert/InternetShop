using Application.Dto;
using Application.Interfaces;
using MediatR;

namespace WebAPI.Functions.Queries.Picture;

public class GetPictureByIdHandler(IPictureService pictureService) : IRequestHandler<GetPictureByIdQuery, PictureDto>
{
    public async Task<PictureDto> Handle(GetPictureByIdQuery request, CancellationToken cancellationToken)
    {
        var picture = await pictureService.GetPictureById(request.PictureId);
        return picture == null ? null : picture;
    }
}