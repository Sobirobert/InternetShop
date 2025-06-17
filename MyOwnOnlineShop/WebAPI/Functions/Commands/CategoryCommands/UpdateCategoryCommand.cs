using MediatR;

namespace WebAPI.Functions.Commands.CategoryCommands;

public record UpdateCategoryCommand(int Id, string CategoryName, string Description) : IRequest;
