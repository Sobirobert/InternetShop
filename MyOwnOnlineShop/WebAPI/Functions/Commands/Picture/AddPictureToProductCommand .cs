using Application.Dto;
using MediatR;

namespace WebAPI.Functions.Commands.Picture;

public record AddPictureToProductCommand(int ProductId, IFormFile File) : IRequest<PictureDto>;