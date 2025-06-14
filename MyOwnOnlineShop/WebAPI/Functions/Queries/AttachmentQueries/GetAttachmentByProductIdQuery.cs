using Application.Dto.AttachmentsDto;
using MediatR;

namespace WebAPI.Functions.Queries.AttachmentQueries;

public class GetAttachmentByProductIdQuery(int productId) : IRequest<IEnumerable<AttachmentDto>>
{
    public int ProductId { get; } = productId;
}
