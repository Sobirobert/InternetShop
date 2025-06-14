using Application.Interfaces;
using MediatR;

namespace WebAPI.Functions.Commands.AttachmentCommands;

public class DeleteAttachmentHandler(IAttachmentService attachmentService, IProductService productService) : IRequestHandler<DeleteAttachmentCommand>
{
    public async Task<Unit> Handle(DeleteAttachmentCommand request, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(request.ProductId);
        if (product == null)
        {
            throw new NullReferenceException($"Product with id {request.ProductId} does not exist.");
        }
        await attachmentService.DelateAttachment(request.AttachmentsId);
        return Unit.Value;
    }
}
