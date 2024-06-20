
using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<List<ShoppingCartItem>> CreateOrder(Order order);

}
