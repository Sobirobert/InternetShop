
using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<ShoppingCartItem>> CreateOrder(Order order, int shoppingCartId);

}
