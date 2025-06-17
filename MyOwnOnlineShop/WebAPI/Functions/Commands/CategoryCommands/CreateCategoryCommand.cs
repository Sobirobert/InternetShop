using MediatR;

namespace WebAPI.Functions.Commands.CategoryCommands;

public record CreateCategoryCommand(string CategoryName, string Description) : IRequest;
