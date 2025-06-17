using Application.Dto.AttachmentsDto;
using MediatR;

namespace WebAPI.Functions.Queries.AttachmentQueries;

public record GetAttachmentByProductIdQuery(int ProductId) : IRequest<IEnumerable<AttachmentDto>>;