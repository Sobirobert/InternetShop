using Application.Interfaces;
using MediatR;

namespace WebAPI.Functions.Commands.Picture;

public class SetMainPictureHandler(IPictureService pictureService) : IRequestHandler<SetMainPictureCommand>
{
    public async Task<Unit> Handle(SetMainPictureCommand request, CancellationToken cancellationToken)
    {
        await pictureService.SetMainPicture(request.ProductId, request.PictureId);
        return Unit.Value;
    }
}
