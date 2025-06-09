using Application.Dto.OrdersDto;
using FluentValidation;

namespace Application.Validators.OrderDtoValidator;
public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(o => o.OrderItems)
            .NotEmpty().WithMessage("Order must contain at least one item")
            .Must(items => items != null && items.Count > 0)
            .WithMessage("Order must contain at least one item");

        //RuleFor(o => o.FirstName)
        //    .NotEmpty().WithMessage("First name is required")
        //    .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

        //RuleFor(o => o.LastName)
        //    .NotEmpty().WithMessage("Last name is required")
        //    .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");

        //RuleFor(o => o.AddressLine1)
        //    .NotEmpty().WithMessage("Address line 1 is required")
        //    .MaximumLength(100).WithMessage("Address line 1 cannot exceed 100 characters");

        //RuleFor(o => o.AddressLine2)
        //    .MaximumLength(100).WithMessage("Address line 2 cannot exceed 100 characters");

        //RuleFor(o => o.ZipCode)
        //    .NotEmpty().WithMessage("Zip code is required")
        //    .Length(4, 10).WithMessage("Zip code must be between 4 and 10 characters");

        //RuleFor(o => o.City)
        //    .NotEmpty().WithMessage("City is required")
        //    .MaximumLength(50).WithMessage("City cannot exceed 50 characters");

        //RuleFor(o => o.State)
        //    .MaximumLength(10).WithMessage("State code cannot exceed 10 characters");

        //RuleFor(o => o.Country)
        //    .NotEmpty().WithMessage("Country is required")
        //    .MaximumLength(50).WithMessage("Country cannot exceed 50 characters");

        //RuleFor(o => o.PhoneNumber)
        //    .NotEmpty().WithMessage("Phone number is required")
        //    .MaximumLength(25).WithMessage("Phone number cannot exceed 25 characters");

        //RuleFor(o => o.Email)
        //    .NotEmpty().WithMessage("Email is required")
        //    .MaximumLength(50).WithMessage("Email cannot exceed 50 characters")
        //    .EmailAddress().WithMessage("Email is in incorrect format")
        //    .Matches(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])")
        //    .WithMessage("Email is in incorrect format");
    }
}
