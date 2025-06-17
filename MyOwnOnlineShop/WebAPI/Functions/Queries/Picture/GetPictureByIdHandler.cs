using Application.Dto;
using Application.Interfaces;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Queries.Picture;

public class GetPictureByIdHandler(IPictureService pictureService) : IRequestHandler<GetPictureByIdQuery, PictureDto>
{
    public async Task<PictureDto> Handle(GetPictureByIdQuery request, CancellationToken cancellationToken)
    {
        var picture = await pictureService.GetPictureById(request.PictureId);
        if (picture == null)
        {
            throw new NotFoundException($"Picture with id {request.PictureId} does not exist.");
        }

        return picture;
    }
}
}