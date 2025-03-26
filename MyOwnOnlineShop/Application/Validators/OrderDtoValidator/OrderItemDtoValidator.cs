using Application.Dto.OrdersDto;
using FluentValidation;

namespace Application.Validators.OrderDtoValidator;

public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
{
    public OrderItemDtoValidator()
    {
        RuleFor(oi => oi.OrderItemId)
            .NotEmpty().WithMessage("Order item ID is required");

        RuleFor(oi => oi.ItemName)
            .NotEmpty().WithMessage("Item name is required")
            .MaximumLength(100).WithMessage("Item name cannot exceed 100 characters");

        RuleFor(oi => oi.OrderId)
            .NotEmpty().WithMessage("Order ID is required")
            .GreaterThan(0).WithMessage("Order ID must be greater than 0");

        RuleFor(oi => oi.ProductId)
            .NotEmpty().WithMessage("Product ID is required")
            .GreaterThan(0).WithMessage("Product ID must be greater than 0");

        RuleFor(oi => oi.Amount)
            .NotEmpty().WithMessage("Amount is required")
            .GreaterThan(0).WithMessage("Amount must be greater than 0");

        RuleFor(oi => oi.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
