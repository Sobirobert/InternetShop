using Application.Dto;
using Application.Interfaces;
using MediatR;
using WebAPI.Commands.Picture;

namespace WebAPI.Handlers.Picture;

public class AddToProductAsyncHandler : IRequestHandler<AddToProductAsyncCommand, PictureDto>
{
    private readonly IPictureService _pictureService;

    public AddToProductAsyncHandler(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }

    public async Task<PictureDto> Handle(AddToProductAsyncCommand request, CancellationToken cancellationToken)
    {
        var picture = await _pictureService.AddPictureToProduct(request.ProductId, request.File);
        return picture;
    }
}
