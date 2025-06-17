using Application.Dto.AttachmentsDto;
using Application.Interfaces;
using Application.Services;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Queries.AttachmentQueries;

public class GetAttachmentByProductIdHandler(IAttachmentService attachmentService, IProductService productService) : IRequestHandler<GetAttachmentByProductIdQuery, IEnumerable<AttachmentDto>>
{
    public async Task<IEnumerable<AttachmentDto>> Handle(GetAttachmentByProductIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(request.ProductId);
        if (product == null)
        {
            throw new NotFoundException($"Product with id {request.ProductId} does not exist.");
        }

        var attachments = await attachmentService.GetAttachmentsByProductId(request.ProductId);
        return attachments;
    }
}
