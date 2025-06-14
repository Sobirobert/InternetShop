using Application.Dto.AttachmentsDto;
using MediatR;

namespace WebAPI.Functions.Queries.AttachmentQueries;

public class DownloadAttachmentQuery(int id, int productId) : IRequest<DownloadAttachmentDto>
{
    public int Id { get; } = id;
    public int ProductId { get; } = productId;
}
