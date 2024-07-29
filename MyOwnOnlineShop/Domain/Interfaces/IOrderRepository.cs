using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<ShoppingCart>> CreateOrder(Order order, int shoppingCartId);
}