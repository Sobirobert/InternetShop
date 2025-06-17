using Application.Dto;
using Application.Interfaces;
using Application.Services;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Commands.Picture;

public class AddPictureToProductHandler(IPictureService pictureService, IProductService productService) : IRequestHandler<AddPictureToProductCommand, PictureDto>
{
    public async Task<PictureDto> Handle(AddPictureToProductCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0)
        {
            throw new BadRequestException("Product ID must be greater than 0.");
        }

        if (request.File == null)
        {
            throw new BadRequestException("File is required.");
        }

        if (request.File.Length == 0)
        {
            throw new BadRequestException("File cannot be empty.");
        }

        // Walidacja typu pliku (opcjonalne)
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
        var fileExtension = Path.GetExtension(request.File.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(fileExtension))
        {
            throw new BadRequestException("Only image files are allowed (jpg, jpeg, png, gif, bmp).");
        }

        // Walidacja rozmiaru pliku (opcjonalne)
        if (request.File.Length > 5 * 1024 * 1024) // 5MB
        {
            throw new BadRequestException("File size cannot exceed 5MB.");
        }

        // Sprawdź czy produkt istnieje
        var product = await productService.GetProductById(request.ProductId);
        if (product == null)
        {
            throw new NotFoundException($"Product with id {request.ProductId} does not exist.");
        }

        var picture = await pictureService.AddPictureToProduct(request.ProductId, request.File);
        return picture;
    }
}
