using Application.Dto;
using Application.Dto.OrderDto;
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

        public async Task<IEnumerable<OrderDto>> GetAllOrders(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
        {
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

        public async Task<double> GetOrdersTotal(int orderId)
        {
           return await _orderRepository.GetOrdersTotal(orderId);
        }

        public async Task<OrderDto> CreateOrder(CreateOrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.CreateOrder(order);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task AddToOrder(int orderId, int amount, int productId)
        {
            await _orderRepository.AddToOrder(orderId, amount, productId);
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
}