using Application.Dto;
using MediatR;

namespace WebAPI.Functions.Queries.Picture;

public record GetPicrtureByProductIdQuery(int ProductId) : IRequest<IEnumerable<PictureDto>>;