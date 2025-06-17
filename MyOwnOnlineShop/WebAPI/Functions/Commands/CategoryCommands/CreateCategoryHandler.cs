using Application.Dto.CategoryDto;
using Application.Interfaces;
using MediatR;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Commands.CategoryCommands;

public class CreateCategoryHandler(ICategoryService categoryService)
    : IRequestHandler<CreateCategoryCommand>
{
    public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.CategoryName))
        {
            throw new BadRequestException("Category name is required.");
        }

        var categoryExists = await categoryService.GetCategoryByName(request.CategoryName);
        if (categoryExists != null)
        {
            throw new ConflictException("Category already exists!");
        }

        var createCategoryDto = new CreateCategoryDto
        (
            CategoryName: request.CategoryName,
            Description: request.Description
        );

        await categoryService.CreateCategory(createCategoryDto);
        return Unit.Value;
    }
}
