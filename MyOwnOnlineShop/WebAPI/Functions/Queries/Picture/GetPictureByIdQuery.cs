using Application.Dto;
using MediatR;

namespace WebAPI.Functions.Queries.Picture;

public class GetPictureByIdQuery : IRequest<PictureDto>
{
    public int PictureId { get; set; }
    public GetPictureByIdQuery(int pictureId)
    {
        PictureId = pictureId;
    }
}
