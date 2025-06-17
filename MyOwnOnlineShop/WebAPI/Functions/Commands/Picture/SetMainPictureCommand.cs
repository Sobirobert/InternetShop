using MediatR;

namespace WebAPI.Functions.Commands.Picture;

public record SetMainPictureCommand(int ProductId, int PictureId) : IRequest;