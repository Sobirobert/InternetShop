using MediatR;

namespace WebAPI.Functions.Commands.Picture;

public class SetMainPictureCommand(int productId, int pictureId) : IRequest
{
    public int ProductId { get; } = productId;
    public int PictureId { get; } = pictureId;
}
