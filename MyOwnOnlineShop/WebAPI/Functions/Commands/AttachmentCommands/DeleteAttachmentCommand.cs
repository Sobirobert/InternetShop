using MediatR;

namespace WebAPI.Functions.Commands.AttachmentCommands;

public record DeleteAttachmentCommand(int AttachmentsId, int ProductId) : IRequest;