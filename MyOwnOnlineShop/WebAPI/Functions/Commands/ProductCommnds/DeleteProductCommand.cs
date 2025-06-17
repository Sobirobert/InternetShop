using MediatR;

namespace WebAPI.Functions.Commands.ProductCommnds;

public record DeleteProductCommand(int Id) : IRequest;