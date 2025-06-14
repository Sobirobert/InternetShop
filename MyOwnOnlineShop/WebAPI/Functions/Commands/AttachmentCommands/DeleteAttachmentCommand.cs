using MediatR;

namespace WebAPI.Functions.Commands.AttachmentCommands;

public class DeleteAttachmentCommand(int attachmentsId, int productId) : IRequest
{
    public int AttachmentsId { get; } = attachmentsId;
    public int ProductId { get; } = productId;
}
