using MediatR;

namespace WebAPI.Commands.Picture;

public class SetMainPictureCommand : IRequest
{
    public int ProductId { get; set; }
    public int PictureId { get; set; }
    public SetMainPictureCommand(int productId, int pictureId)
    {
        ProductId = productId;
        PictureId = pictureId;
    }
}
