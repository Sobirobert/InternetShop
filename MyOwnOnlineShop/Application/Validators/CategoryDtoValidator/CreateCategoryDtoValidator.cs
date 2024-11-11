using Application.Dto.CategoryDto;
using FluentValidation;

namespace Application.Validators.CategoryDtoValidator;
public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        #region CategoryName

        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("The Category name cannot be empty.");
        RuleFor(x => x.CategoryName).Length(3, 100).WithMessage("The Category name must be between 3 and 100 characters long.");

        #endregion CategoryName

        #region Description

        RuleFor(x => x.Description).NotEmpty().WithMessage("The Description of a Category name cannot be empty.");
        RuleFor(x => x.Description).Length(3, 300).WithMessage("The category description must be between 3 and 100 characters long.");

        #endregion Description
    }
}
