using Application.Dto.OrdersDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Builders;
using Microsoft.Extensions.Logging;
using static Application.Dto.OrdersDto.CreateOrderDto;
using static Domain.Entities.Order;

namespace Application.Services;
public class OrderService(IOrderRepository orderRepository, IMapper mapper, ILogger<OrderService> logger) : IOrderService
{
    public async Task<IEnumerable<OrderDto>> GetAllOrders(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        logger.LogDebug("Fetching Orders");
        logger.LogInformation($"pageNumber: {pageNumber} | pageSize: {pageSize}");
        var orders = await orderRepository.GetAll(pageNumber, pageSize, sortField, ascending, filterBy);
        return mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto> GetOrderById(int id)
    {
        var order = await orderRepository.GetById(id);
        return mapper.Map<OrderDto>(order);    
    }

    public async Task<int> GetAllOrdersCount(string filterBy)
    {
        return await orderRepository.GetAllCount(filterBy);
    }

    public async Task<OrderDto> CreateOrder(CreateOrderDto orderDto, AdressDto adressDto, ContactDto contactDto, PersonalInfoDto infoDto)
    {
        var info = mapper.Map<PersonalInfo>(orderDto);
        var contact = mapper.Map<Contact>(orderDto);
        var adress = mapper.Map<Adress>(orderDto);
        var order = mapper.Map<Order>(orderDto);
        var newOrder = new OrderBuilder()
         .SetId(order.OrderId)
         .SetPublicId()
         .SetShippingStatus(order.ShippingStatus)
         .SetPaymentStatus(order.PaymentStatus)
         .SetShoppingCardsItems(order.ProductsList)
         .SetTotalPrice(order.ProductsList)
         .SetAdress(adress)
         .SetContact(contact)
         .SetPersonalInfo(info)
         .SetOrderPlaced()
         .Build();
        await orderRepository.CreateOrder(newOrder);
        return mapper.Map<OrderDto>(order);
    }

    public async Task DeleteOrder(int id)
    {
        await orderRepository.Delete(id);
    }

    public async Task UpdateOrder(UpdateOrderDto orderDto)
    {
        var existingOrder = await orderRepository.GetById(orderDto.OrderId);
        var order = mapper.Map(orderDto, existingOrder);
        await orderRepository.Update(order);
    }
}