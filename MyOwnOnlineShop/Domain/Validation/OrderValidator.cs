using Domain.Entities;
using FluentValidation;

namespace Domain.Validation;
public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.OrderId)
            .NotEmpty().WithMessage("Order ID is required");

        RuleFor(o => o.ShippingStatus)
            .IsInEnum().WithMessage("Invalid shipping status")
            .NotEmpty().WithMessage("Shipping status is required");

        RuleFor(o => o.PaymentStatus)
            .IsInEnum().WithMessage("Invalid payment status")
            .NotEmpty().WithMessage("Payment status is required");

        RuleFor(o => o.TotalPrice)
            .NotEmpty().WithMessage("Total price is required")
            .GreaterThan(0).WithMessage("Total price must be greater than 0");

        RuleFor(o => o.OrderPlaced)
            .NotEmpty().WithMessage("Order placed date is required")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Order placed date cannot be in the future");

        RuleFor(o => o.ProductsList)
            .NotEmpty().WithMessage("Order must contain at least one product")
            .Must(products => products != null && products.Count > 0)
            .WithMessage("Order must contain at least one product");

        RuleFor(o => o.DeliveryAddress)
            .SetValidator(new AddressValidator())
            .When(o => o.DeliveryAddress != null);

        RuleFor(o => o.CustomerContact)
            .SetValidator(new ContactValidator())
            .When(o => o.CustomerContact != null);

        RuleFor(o => o.CustomerInfo)
            .SetValidator(new PersonalInfoValidator())
            .When(o => o.CustomerInfo != null);
    
    }
}
