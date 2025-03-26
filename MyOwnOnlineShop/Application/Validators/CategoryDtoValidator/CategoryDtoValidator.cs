using Application.Dto.CategoryDto;
using FluentValidation;

namespace Application.Validators.CategoryDtoValidator;
public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(c => c.CategoryName)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters");

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Category description is required")
            .MaximumLength(500).WithMessage("Category description cannot exceed 500 characters");
    }
}
