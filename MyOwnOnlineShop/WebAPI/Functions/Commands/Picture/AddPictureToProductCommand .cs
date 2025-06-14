using Application.Dto;
using MediatR;

namespace WebAPI.Functions.Commands.Picture;

public class AddPictureToProductCommand(int productId, IFormFile file) : IRequest<PictureDto>
{
    public int ProductId { get; } = productId;
    public IFormFile File { get; } = file;
}
