using Application.Dto;
using Application.Interfaces;
using Application.Services;
using MediatR;

namespace WebAPI.Functions.Commands.Picture;

public class AddPictureToProductHandler(IPictureService pictureService) : IRequestHandler<AddPictureToProductCommand, PictureDto>
{
    public async Task<PictureDto> Handle(AddPictureToProductCommand request, CancellationToken cancellationToken)
    {
        var picture = await pictureService.AddPictureToProduct(request.ProductId, request.File);
        return picture;
    }
}
