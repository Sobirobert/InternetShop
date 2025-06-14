using Domain.Entities;

namespace Domain.Interfaces;
public interface IOrderRepository
{
    Task<Order> CreateOrder(Order order);
    Task<IEnumerable<Order>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
    Task<int> GetAllCount(string filterBy);
    Task<Order> GetById(int id);
    Task Update(Order order);
    Task Delete(int id);
}