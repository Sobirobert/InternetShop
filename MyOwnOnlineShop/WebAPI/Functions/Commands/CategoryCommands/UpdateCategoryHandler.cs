using Application.Dto.CategoryDto;
using Application.Interfaces;
using Infrastructure.Identity;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System.Security.Claims;

namespace WebAPI.Functions.Commands.CategoryCommands;

public class UpdateCategoryHandler(ICategoryService categoryService, IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<UpdateCategoryCommand>
{
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var userClaims = httpContextAccessor.HttpContext?.User;
        var userRole = userClaims?.FindFirstValue(ClaimTypes.Role);

        if (string.IsNullOrEmpty(userRole) || !userRole.Contains(UserRoles.Admin))
        {
            throw new ForbiddenException("You can't change category.");
        }

        var existingCategory = await categoryService.GetCategoryById(request.Id);
        if (existingCategory == null)
        {
            throw new NotFoundException("Category isn't exists!");
        }

        if (string.IsNullOrWhiteSpace(request.CategoryName))
        {
            throw new BadRequestException("Category name is required.");
        }

        var updateCategoryDto = new UpdateCategoryDto(
            Id: request.Id,
            CategoryName: request.CategoryName,
            Description: request.Description
        );

        await categoryService.UpdateCategory(updateCategoryDto);

        return Unit.Value;
    }
}
