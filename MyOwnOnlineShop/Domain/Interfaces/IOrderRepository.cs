using Domain.Entities;

namespace Domain.Interfaces;
public interface IOrderRepository
{
    Task CreateOrder(Order order);
    Task AddToOrder(int orderId, int amount, int productId);
    Task<double> GetShoppingCartTotal(int orderId);
    Task<IEnumerable<Order>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
    Task<Order> GetById(int id);
    Task Update(Order order);
    Task Delete(int id);
}