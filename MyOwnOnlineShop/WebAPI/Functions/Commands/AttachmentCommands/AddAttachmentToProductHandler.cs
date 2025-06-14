using Application.Dto.AttachmentsDto;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace WebAPI.Functions.Commands.AttachmentCommands;

public class AddAttachmentToProductHandler(IAttachmentService attachmentService, IProductService productService, IMapper mapper) : IRequestHandler<AddAttachmentToProductCommand, AttachmentDto>
{
    public async Task<AttachmentDto> Handle(AddAttachmentToProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(request.ProductId);
        if (product == null)
        {
            throw new NullReferenceException($"Product with id {request.ProductId} does not exist.");
        }

       var attachment=  await attachmentService.AddAttachmentToProduct(request.ProductId, request.File);
       return mapper.Map<AttachmentDto>(attachment);
    }
}
