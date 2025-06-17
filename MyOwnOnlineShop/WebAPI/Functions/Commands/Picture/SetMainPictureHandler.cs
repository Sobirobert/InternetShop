using Application.Interfaces;
using Application.Services;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Commands.Picture;

public class SetMainPictureHandler(IPictureService pictureService, IProductService productService) : IRequestHandler<SetMainPictureCommand>
{
    public async Task<Unit> Handle(SetMainPictureCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0)
        {
            throw new BadRequestException("Product ID must be greater than 0.");
        }

        if (request.PictureId <= 0)
        {
            throw new BadRequestException("Picture ID must be greater than 0.");
        }

        var product = await productService.GetProductById(request.ProductId);
        if (product == null)
        {
            throw new NotFoundException($"Product with id {request.ProductId} does not exist.");
        }

        var picture = await pictureService.GetPictureById(request.PictureId);
        if (picture == null)
        {
            throw new NotFoundException($"Picture with id {request.PictureId} does not exist.");
        }

        await pictureService.SetMainPicture(request.ProductId, request.PictureId);
        return Unit.Value;
    }
}
