using Domain.Entities;
using FluentValidation;

namespace Domain.Validation;

public class AddressValidator : AbstractValidator<Order.Adress>
{
    public AddressValidator()
    {
        RuleFor(a => a.AddressLine1)
            .NotEmpty().WithMessage("Address line 1 is required")
            .MaximumLength(100).WithMessage("Address line 1 cannot exceed 100 characters");

        RuleFor(a => a.AddressLine2)
            .MaximumLength(100).WithMessage("Address line 2 cannot exceed 100 characters");

        RuleFor(a => a.ZipCode)
            .NotEmpty().WithMessage("Zip code is required")
            .Length(4, 10).WithMessage("Zip code must be between 4 and 10 characters");

        RuleFor(a => a.City)
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(50).WithMessage("City cannot exceed 50 characters");

        RuleFor(a => a.State)
            .MaximumLength(50).WithMessage("State cannot exceed 50 characters");

        RuleFor(a => a.Country)
            .NotEmpty().WithMessage("Country is required")
            .MaximumLength(50).WithMessage("Country cannot exceed 50 characters");
    }
}
