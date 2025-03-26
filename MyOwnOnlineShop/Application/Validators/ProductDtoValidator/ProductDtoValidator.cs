using Application.Dto.ProductDtoFolder;
using FluentValidation;

namespace Application.Validators.ProductDtoValidator;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Product ID is required");

        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("Product title is required")
            .MaximumLength(100).WithMessage("Product title cannot exceed 100 characters");

        RuleFor(p => p.ShortDescription)
            .NotEmpty().WithMessage("Short description is required")
            .MaximumLength(200).WithMessage("Short description cannot exceed 200 characters");

        RuleFor(p => p.LongDescription)
            .NotEmpty().WithMessage("Long description is required")
            .MaximumLength(1000).WithMessage("Long description cannot exceed 1000 characters");

        RuleFor(p => p.Details)
            .MaximumLength(500).WithMessage("Details cannot exceed 500 characters");

        RuleFor(p => p.YearOfProduction)
            .NotEmpty().WithMessage("Year of production is required")
            .GreaterThan(1900).WithMessage("Year of production must be after 1900")
            .LessThanOrEqualTo(System.DateTime.Now.Year).WithMessage($"Year of production cannot be in the future");

        RuleFor(p => p.Amount)
            .NotEmpty().WithMessage("Amount is required")
            .GreaterThanOrEqualTo(0).WithMessage("Amount cannot be negative");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(p => p.Type)
            .IsInEnum().WithMessage("Invalid product type")
            .NotEmpty().WithMessage("Product type is required");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Category ID is required")
            .GreaterThan(0).WithMessage("Category ID must be greater than 0");
    }
}
