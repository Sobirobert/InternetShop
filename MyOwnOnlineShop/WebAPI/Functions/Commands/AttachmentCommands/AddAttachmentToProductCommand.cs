using Application.Dto.AttachmentsDto;
using MediatR;

namespace WebAPI.Functions.Commands.AttachmentCommands;

public record AddAttachmentToProductCommand(int ProductId, IFormFile File) : IRequest<AttachmentDto>;
