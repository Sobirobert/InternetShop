using MediatR;

namespace WebAPI.Functions.Commands.Picture;

public class DelateCommand : IRequest
{
    public int PictureId { get; set; }
    public DelateCommand(int productId)
    {
        PictureId = productId;
    }
}