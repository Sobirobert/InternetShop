using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<ShoppingCard>> CreateOrder(Order order, int shoppingCartId);
}