using MediatR;

namespace WebAPI.Commands.Picture;

public class DelateCommand : IRequest
{
    public int PictureId { get; set; }
    public DelateCommand(int productId)
    {
        PictureId = productId;
    }
}