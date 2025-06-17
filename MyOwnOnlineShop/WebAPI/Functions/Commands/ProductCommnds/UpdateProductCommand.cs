using Application.Dto.ProductDtoFolder;
using MediatR;

namespace WebAPI.Functions.Commands.ProductCommnds;

public record UpdateProductCommand(UpdateProductDto UpdateProductDto) : IRequest;