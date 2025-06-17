using Application.Dto;
using MediatR;

namespace WebAPI.Functions.Queries.Picture;

public record GetPictureByIdQuery(int PictureId) : IRequest<PictureDto>;