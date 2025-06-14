using Application.Interfaces;
using MediatR;
using WebAPI.Functions.Commands.Picture;

namespace WebAPI.Functions.Handlers.Picture;

public class DeleteHandler(IPictureService pictureService) : IRequestHandler<DelateCommand>
{
    public async Task<Unit> Handle(DelateCommand request, CancellationToken cancellationToken)
    {
        await pictureService.DeletePicture(request.PictureId);
        return Unit.Value;
    }
}
