using Application.Dto;
using MediatR;

namespace WebAPI.Commands.Picture;

public class AddToProductAsyncCommand : IRequest<PictureDto>
{
    public int ProductId { get; set; }
    public IFormFile File { get; set; }
    public AddToProductAsyncCommand(int productId, IFormFile file)
    {
        ProductId = productId;
        File = file;
    }
}
