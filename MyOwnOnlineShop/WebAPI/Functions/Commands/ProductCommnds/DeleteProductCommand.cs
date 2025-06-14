using MediatR;

namespace WebAPI.Functions.Commands.ProductCommnds;

public class DeleteProductCommand(int id) : IRequest
{
    public int Id { get; } = id;
}
