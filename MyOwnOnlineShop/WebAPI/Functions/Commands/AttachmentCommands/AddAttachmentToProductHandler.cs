using Application.Dto.AttachmentsDto;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Commands.AttachmentCommands;

public class AddAttachmentToProductHandler(IAttachmentService attachmentService, IProductService productService, IMapper mapper) : IRequestHandler<AddAttachmentToProductCommand, AttachmentDto>
{
    public async Task<AttachmentDto> Handle(AddAttachmentToProductCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0)
        {
            throw new BadRequestException("Product ID must be greater than 0.");
        }

        if (request.File == null)
        {
            throw new BadRequestException("File is required.");
        }

        var product = await productService.GetProductById(request.ProductId);
        if (product == null)
        {
            throw new NotFoundException($"Product with id {request.ProductId} does not exist.");
        }

        if (request.File.Length == 0)
        {
            throw new BadRequestException("File cannot be empty.");
        }

        if (request.File.Length > 10 * 1024 * 1024) // 10MB
        {
            throw new BadRequestException("File size cannot exceed 10MB.");
        }

        var attachment = await attachmentService.AddAttachmentToProduct(request.ProductId, request.File);
        return mapper.Map<AttachmentDto>(attachment);
    }
}
