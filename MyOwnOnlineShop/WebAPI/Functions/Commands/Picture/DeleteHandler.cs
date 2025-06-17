using Application.Interfaces;
using MediatR;
using WebAPI.Functions.Commands.Picture;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Handlers.Picture;

public class DeleteHandler(IPictureService pictureService) : IRequestHandler<DelateCommand>
{
    public async Task<Unit> Handle(DelateCommand request, CancellationToken cancellationToken)
    {
        if (request.PictureId <= 0)
        {
            throw new BadRequestException("Picture ID must be greater than 0.");
        }

        // Sprawdź czy zdjęcie istnieje
        var picture = await pictureService.GetPictureById(request.PictureId);
        if (picture == null)
        {
            throw new NotFoundException($"Picture with id {request.PictureId} does not exist.");
        }

        await pictureService.DeletePicture(request.PictureId);
        return Unit.Value;
    }
}

