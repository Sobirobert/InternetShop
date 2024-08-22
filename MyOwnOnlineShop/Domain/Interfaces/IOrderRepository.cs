using Domain.Entities;

namespace Domain.Interfaces;
public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
    Task<Order> GetById(int id);
    Task<Order> Add(Order order);
    Task Update(Order order);
    Task Delete(int id);
}