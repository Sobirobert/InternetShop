using Application.Interfaces;
using Azure.Core;
using Infrastructure.Identity;
using k8s.KubeConfigModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using System.Security.Claims;

namespace WebAPI.Functions.Commands.CategoryCommands;

public class DeleteCategoryHandler(ICategoryService categoryService, IHttpContextAccessor httpContextAccessor) : ControllerBase, IRequestHandler<DeleteCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var userClaims = httpContextAccessor.HttpContext?.User;
        var userRole = userClaims?.FindFirstValue(ClaimTypes.Role);

        if (string.IsNullOrEmpty(userRole) || !userRole.Contains(UserRoles.Admin))
        {
            throw new ForbiddenException("You aren't Admin! Only Admin can delete Category");
        }

        var existCategory = await categoryService.GetCategoryById(request.CategoryId);
        if (existCategory == null)
        {
            throw new NotFoundException("Category isn't exists!");
        }

        await categoryService.DeleteCategory(request.CategoryId);
        return Unit.Value;
    }
}
