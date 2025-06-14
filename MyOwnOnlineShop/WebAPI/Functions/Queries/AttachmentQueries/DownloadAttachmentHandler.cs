using Application.Dto.AttachmentsDto;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace WebAPI.Functions.Queries.AttachmentQueries;
public class DownloadAttachmentHandler(IAttachmentService attachmentService, IProductService productService) : IRequestHandler<DownloadAttachmentQuery, DownloadAttachmentDto>
{
    public async Task<DownloadAttachmentDto> Handle(DownloadAttachmentQuery request, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(request.ProductId);
        if (product == null)
        {
            throw new NotImplementedException($"Product with id {request.ProductId} does not exist.");
        }

        var attachment = await attachmentService.DownloadAttachmentById(request.Id);
        if (attachment == null)
        {
            throw new FileNotFoundException();
        }
        return attachment;
    }
}
