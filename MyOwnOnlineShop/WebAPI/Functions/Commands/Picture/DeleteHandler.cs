using Application.Interfaces;
using MediatR;
using WebAPI.Functions.Commands.Picture;

namespace WebAPI.Functions.Handlers.Picture;

public class DeleteHandler : IRequestHandler<DelateCommand>
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
