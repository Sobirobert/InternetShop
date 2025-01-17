using Application.Interfaces;
using MediatR;
using WebAPI.Commands.Picture;

namespace WebAPI.Handlers.Picture;

public class DeleteHandler : IRequestHandler<DelateCommand, Unit>
{
    private readonly IPictureService _pictureService;
    public DeleteHandler(IPictureService pictureService)
    {
        _pictureService = pictureService;
}
    public async Task<Unit> Handle(DelateCommand request, CancellationToken cancellationToken)
    {
        await _pictureService.DeletePicture(request.PictureId);
        return Unit.Value;
    }
}
