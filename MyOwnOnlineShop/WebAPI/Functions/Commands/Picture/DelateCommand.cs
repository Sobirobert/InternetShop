using MediatR;

namespace WebAPI.Functions.Commands.Picture;

public record DelateCommand(int PictureId) : IRequest;