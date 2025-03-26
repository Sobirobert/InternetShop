using Domain.Entities;
using FluentValidation;

namespace Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("Product title is required")
            .Length(2, 100).WithMessage("Product title must be between 2 and 100 characters");

        RuleFor(p => p.ShortDescription)
            .NotEmpty().WithMessage("Short description is required")
            .MaximumLength(250).WithMessage("Short description cannot exceed 250 characters");

        RuleFor(p => p.LongDescription)
            .NotEmpty().WithMessage("Long description is required")
            .MaximumLength(4000).WithMessage("Long description cannot exceed 4000 characters");

        RuleFor(p => p.Amount)
            .GreaterThanOrEqualTo(0).WithMessage("Amount cannot be negative");

        RuleFor(p => p.Details)
            .NotEmpty().WithMessage("Product details are required")
            .MaximumLength(2000).WithMessage("Product details cannot exceed 2000 characters");

        RuleFor(p => p.YearOfProduction)
            .NotEmpty().WithMessage("Year of production is required")
            .GreaterThan(1900).WithMessage("Year of production must be greater than 1900")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Year of production cannot be later than the current year ({DateTime.Now.Year})");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .LessThan(1000000).WithMessage("Price cannot exceed 1,000,000");

        RuleFor(p => p.Type)
            .IsInEnum().WithMessage("Invalid product type");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Category is required")
            .GreaterThan(0).WithMessage("Category ID must be greater than 0");

        RuleFor(p => p)
            .Must(p => !(p.Price > 10000 && p.Amount > 50))
            .WithMessage("For products priced above 10,000, the maximum available quantity is 50 units")
            .When(p => p.Price > 0 && p.Amount > 0);

        When(p => p.IsProductOfTheWeek, () =>
        {
            RuleFor(p => p.Price)
                .LessThan(5000).WithMessage("Products of the week cannot cost more than 5,000");

            RuleFor(p => p.Amount)
                .GreaterThan(5).WithMessage("Product of the week must be available in quantities greater than 5 units");
        });
    }
}

