using Application.Dto.Order;
using Application.Dto.ShoppingcartItemDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<ShoppingCartDto>> CreateOrder(OrderDto orderDto, int shoppingCartId)
        {
            var order = _mapper.Map<Order>(orderDto);
            var orderList = await _orderRepository.CreateOrder(order, shoppingCartId);
            return _mapper.Map<List<ShoppingCartDto>>(orderList);
        }
    }
}