using Application.Dto.AttachmentsDto;
using MediatR;

namespace WebAPI.Functions.Commands.AttachmentCommands;

public class AddAttachmentToProductCommand(int productId, IFormFile file) : IRequest<AttachmentDto>
{
    public int ProductId { get; } = productId;
    public IFormFile File { get; } = file;
}
