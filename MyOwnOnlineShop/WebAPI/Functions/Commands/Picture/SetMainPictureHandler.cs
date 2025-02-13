using Application.Interfaces;
using MediatR;

namespace WebAPI.Functions.Commands.Picture;

public class SetMainPictureHandler : IRequestHandler<SetMainPictureCommand, Unit>
{
    private readonly IPictureService _pictureService;
    public SetMainPictureHandler(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }

    public async Task<Unit> Handle(SetMainPictureCommand request, CancellationToken cancellationToken)
    {
        await _pictureService.SetMainPicture(request.ProductId, request.PictureId);
        return Unit.Value;
    }
}
