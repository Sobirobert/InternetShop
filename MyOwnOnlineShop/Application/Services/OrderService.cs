using Application.Dto.OrdersDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using static Application.Dto.OrdersDto.CreateOrderDto;
using static Domain.Entities.Order;

namespace Application.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public OrderService(IOrderRepository orderRepository, IMapper mapper, ILogger<OrderService> logger)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrders(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        _logger.LogDebug("Fetching Orders");
        _logger.LogInformation($"pageNumber: {pageNumber} | pageSize: {pageSize}");
        var orders = await _orderRepository.GetAll(pageNumber, pageSize, sortField, ascending, filterBy);
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto> GetOrderById(int id)
    {
        var order = await _orderRepository.GetById(id);
        return _mapper.Map<OrderDto>(order);    
    }

    public async Task<int> GetAllOrdersCount(string filterBy)
    {
        return await _orderRepository.GetAllCount(filterBy);
    }

    public async Task<OrderDto> CreateOrder(CreateOrderDto orderDto, AdressDto adressDto, ContactDto contactDto, PersonalInfoDto infoDto)
    {
        var info = _mapper.Map<PersonalInfo>(orderDto);
        var contact = _mapper.Map<Contact>(orderDto);
        var adress = _mapper.Map<Adress>(orderDto);
        var order = _mapper.Map<Order>(orderDto);
        await _orderRepository.CreateOrder(order, adress, contact, info);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task DeleteOrder(int id)
    {
        await _orderRepository.Delete(id);
    }

    public async Task UpdateOrder(UpdateOrderDto orderDto)
    {
        var existingOrder = await _orderRepository.GetById(orderDto.OrderId);
        var order = _mapper.Map(orderDto, existingOrder);
        await _orderRepository.Update(order);
    }
}