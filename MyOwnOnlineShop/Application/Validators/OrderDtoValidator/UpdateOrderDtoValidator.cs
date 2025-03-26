using Application.Dto.OrdersDto;
using FluentValidation;

namespace Application.Validators.OrderDtoValidator;

public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidator()
    {
        RuleFor(o => o.OrderId)
            .NotEmpty().WithMessage("Order ID is required");

        RuleFor(o => o.OrderItems)
            .NotEmpty().WithMessage("Order must contain at least one item")
            .Must(items => items != null && items.Count > 0)
            .WithMessage("Order must contain at least one item");

        RuleFor(o => o.ShippingStatus)
            .IsInEnum().WithMessage("Invalid shipping status")
            .NotEmpty().WithMessage("Shipping status is required");

        RuleFor(o => o.PaymentStatus)
            .IsInEnum().WithMessage("Invalid payment status")
            .NotEmpty().WithMessage("Payment status is required");
    }
}
