using Application.Dto;
using FluentValidation;

namespace Application.Validators.ProductDto;
public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        #region Title

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Product title field cannot be empty.")
            .Length(3, 250).WithMessage("Product title must be between 3 and 100 characters long.");

        #endregion Title

        #region DescriptionOfProduct

        RuleFor(x => x.ShortDescription)
            .NotEmpty().WithMessage("Short description field cannot be empty.")
            .Length(3, 4000).WithMessage("Short description must be between 3 and 2500 characters long");

        #endregion DescriptionOfProduct

        #region LongDescriptionOfProduct

        RuleFor(x => x.LongDescription)
            .NotEmpty().WithMessage("Long description field cannot be empty.")
            .Length(3, 5000).WithMessage("Long description must be between 3 and 2500 characters long.");

        #endregion LongDescriptionOfProduct

        #region Price

        RuleFor(x => x.Price)
            .NotNull().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .LessThan(1000000).WithMessage("Price cannot exceed 1,000,000");

        #endregion Price

        #region Type

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type field cannot be empty.")
            .IsInEnum().WithMessage("Invalid product type");

        #endregion Type

        #region Details

        RuleFor(p => p.Details)
                .NotEmpty().WithMessage("Product details are required")
                .MaximumLength(2000).WithMessage("Product details cannot exceed 2000 characters");
        #endregion Details


        #region Amount

        RuleFor(x => x.Amount)
            .NotNull().WithMessage("Amount is required")
            .GreaterThanOrEqualTo(0).WithMessage("Amount cannot be negative");

        #endregion Amount

        #region CategoryId

        RuleFor(x => x.CategoryId)
            .NotNull().WithMessage("Category is required")
            .GreaterThan(0).WithMessage("Category ID must be greater than 0");

        #endregion CategoryId

        #region YearOfProduction

        RuleFor(p => p.YearOfProduction)
              .NotNull().WithMessage("Year of production is required")
              .GreaterThan(1900).WithMessage("Year of production must be greater than 1900")
              .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Year of production cannot be later than the current year ({DateTime.Now.Year})");

        #endregion YearOfProduction

        #region IsProductOfTheWeek

        When(p => p.IsProductOfTheWeek, () =>
        {
            RuleFor(p => p.Price)
                .LessThan(5000).WithMessage("Products of the week cannot cost more than 5,000");

            RuleFor(p => p.Amount)
                .GreaterThan(5).WithMessage("Product of the week must be available in quantities greater than 5 units");
        });

        #endregion IsProductOfTheWeek

        RuleFor(p => p)
              .Must(p => !(p.Price > 10000 && p.Amount > 50))
              .WithMessage("For products priced above 10,000, the maximum available quantity is 50 units")
              .When(p => p.Price > 0 && p.Amount > 0);
    }
}