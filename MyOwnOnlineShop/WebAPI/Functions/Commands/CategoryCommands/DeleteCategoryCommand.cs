using MediatR;

namespace WebAPI.Functions.Commands.CategoryCommands;

public record DeleteCategoryCommand(int CategoryId) : IRequest;