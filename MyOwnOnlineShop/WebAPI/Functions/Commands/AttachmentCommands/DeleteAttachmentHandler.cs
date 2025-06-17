using Application.Interfaces;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Commands.AttachmentCommands;

public class DeleteAttachmentHandler(IAttachmentService attachmentService, IProductService productService) : IRequestHandler<DeleteAttachmentCommand>
{
    public async Task<Unit> Handle(DeleteAttachmentCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0)
        {
            throw new BadRequestException("Product ID must be greater than 0.");
        }

        if (request.AttachmentsId <= 0)
        {
            throw new BadRequestException("Attachment ID must be greater than 0.");
        }

        // Sprawdź czy produkt istnieje
        var product = await productService.GetProductById(request.ProductId);
        if (product == null)
        {
            throw new NotFoundException($"Product with id {request.ProductId} does not exist.");
        }

        try
        {
            await attachmentService.DelateAttachment(request.AttachmentsId);
        }
        catch (InvalidOperationException)
        {
            throw new NotFoundException($"Attachment with id {request.AttachmentsId} does not exist.");
        }

        return Unit.Value;
    }
}
