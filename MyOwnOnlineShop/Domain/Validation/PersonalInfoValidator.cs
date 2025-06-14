using Domain.Entities;
using FluentValidation;

namespace Domain.Validation;

public class PersonalInfoValidator : AbstractValidator<Order.PersonalInfo>
{
    public PersonalInfoValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

        RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");
    }
}
