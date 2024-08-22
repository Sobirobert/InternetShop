using Domain.Entities;

namespace Domain.Interfaces;
public interface IOrderUserDetailsRepository
{
    Task<IEnumerable<OrderUserDetails>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
    Task<OrderUserDetails> GetById(int id);
    Task<OrderUserDetails> Add(OrderUserDetails orderDetails);
    Task Update(OrderUserDetails orderDetails);
    Task Delete(int id);
}
