using Application.Dto;
using MediatR;

namespace WebAPI.Functions.Queries.Picture;

public class GetPictureByIdQuery(int pictureId) : IRequest<PictureDto>
{
    public int PictureId { get; } = pictureId;
}
