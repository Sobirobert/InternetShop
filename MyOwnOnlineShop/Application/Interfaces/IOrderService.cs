using Application.Dto;
using Application.Dto.OrderDto;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<OrderDto> CreateOrder(CreateOrderDto order);
    Task AddToOrder(int orderId, int amount, int productId);
    Task<int> GetAllOrdersCount(string filterBy);
    Task<double> GetOrdersTotal(int orderId);
    Task<IEnumerable<OrderDto>> GetAllOrders(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
    Task<OrderDto> GetOrderById(int id);
    Task UpdateOrder(UpdateOrderDto order);
    Task UpdateOrderItem(UpdateOrderItemDto orderItemDto);
    Task DeleteOrder(int id);
}