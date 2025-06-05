using Application.Dto.OrdersDto;
using static Application.Dto.OrdersDto.CreateOrderDto;

namespace Application.Interfaces;
public interface IOrderService
{
    Task<OrderDto> CreateOrder(CreateOrderDto order, AdressDto adress, ContactDto contact, PersonalInfoDto info);
    Task<int> GetAllOrdersCount(string filterBy);
    Task<IEnumerable<OrderDto>> GetAllOrders(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
    Task<OrderDto> GetOrderById(int id);
    Task UpdateOrder(UpdateOrderDto order);
    Task DeleteOrder(int id);
}