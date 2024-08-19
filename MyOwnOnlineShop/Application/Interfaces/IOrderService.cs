using Application.Dto.Order;
using Application.Dto.ShoppingcartItemDto;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<List<ShoppingCardDto>> CreateOrder(OrderDto orderDto, int shoppingCartId);
}