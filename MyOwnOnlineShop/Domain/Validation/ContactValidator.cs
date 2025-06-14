using Domain.Entities;
using FluentValidation;

namespace Domain.Validation;

public class ContactValidator : AbstractValidator<Order.Contact>
{
    public ContactValidator()
    {
        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .MaximumLength(25).WithMessage("Phone number cannot exceed 25 characters")
            .Matches(@"^[\+]?[0-9\s\-\(\)]{7,25}$").WithMessage("Phone number format is invalid");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(100).WithMessage("Email cannot exceed 100 characters")
            .EmailAddress().WithMessage("Email format is invalid");
    }
}

