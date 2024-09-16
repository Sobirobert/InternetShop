using Domain.Entities;

namespace Domain.Interfaces;
public interface IOrderRepository
{
    Task<Order> CreateOrder(Order order);
    Task AddToOrder(int orderId, int amount, int productId);
    Task<double> GetOrdersTotal(int orderId);
    Task<IEnumerable<Order>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
    Task<int> GetAllCount(string filterBy);
    Task<Order> GetById(int id);
    Task<OrderItem> GetItemById(int id);
    Task Update(Order order);
    Task Update(OrderItem orderItem);
    Task Delete(int id);
}