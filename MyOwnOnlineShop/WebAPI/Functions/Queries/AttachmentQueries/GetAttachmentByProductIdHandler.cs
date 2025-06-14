using Application.Dto.AttachmentsDto;
using Application.Interfaces;
using MediatR;

namespace WebAPI.Functions.Queries.AttachmentQueries;

public class GetAttachmentByProductIdHandler(IAttachmentService attachmentService) : IRequestHandler<GetAttachmentByProductIdQuery, IEnumerable<AttachmentDto>>
{
    public async Task<IEnumerable<AttachmentDto>> Handle(GetAttachmentByProductIdQuery request, CancellationToken cancellationToken)
    {
        var pictures = await attachmentService.GetAttachmentsByProductId(request.ProductId);
        return pictures;
    }
}
