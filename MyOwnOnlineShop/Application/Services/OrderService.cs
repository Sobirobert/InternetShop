using Application.Dto;
using Application.Dto.Order;
using Application.Dto.ShoppingcartItemDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<ShoppingCartItemDto>> CreateOrder(OrderDto orderDto)
        {            
            var order = _mapper.Map<Order>(orderDto);
            var orderList = await _orderRepository.CreateOrder(order);
            return _mapper.Map<List<ShoppingCartItemDto>>(orderList);
        }
    }
    //public async Task AddToCartAsync(Product product)
    //{
    //    var shoppingCartItem =
    //                await _context.ShoppingCartItems.SingleOrDefaultAsync(
    //                     s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

    //    if (shoppingCartItem == null)
    //    {
    //        shoppingCartItem = new ShoppingCartItem
    //        {
    //            ShoppingCartId = ShoppingCartId,
    //            Product = product,
    //            Amount = 1
    //        };

    //        await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
    //    }
    //    else
    //    {
    //        shoppingCartItem.Amount++;
    //    }
    //    await _context.SaveChangesAsync();

    //}

    //public async Task<List<ShoppingCartItem>> GetShoppingCartItemsAsync()
    //{
    //    return ShoppingCartItems ??
    //               (ShoppingCartItems =
    //                  await _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
    //                       .Include(s => s.Product)
    //                       .ToListAsync());
    //}

    //public async Task<double> GetShoppingCartTotalAsync()
    //{
    //    var total = await _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
    //            .Select(c => c.Product.Price * c.Amount).SumAsync();
    //    return total;
    //}

    //public async Task ClearCartAsync()
    //{
    //    var cartItems = _context
    //            .ShoppingCartItems
    //            .Where(cart => cart.ShoppingCartId == ShoppingCartId);

    //    _context.ShoppingCartItems.RemoveRange(cartItems);

    //    await _context.SaveChangesAsync();
    //}
    //public async Task RemoveFromCartAsync(Product product)
    //{
    //    var shoppingCartItem =
    //              await _context.ShoppingCartItems.SingleOrDefaultAsync(
    //                   s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

    //    var localAmount = 0;

    //    if (shoppingCartItem != null)
    //    {
    //        if (shoppingCartItem.Amount > 1)
    //        {
    //            shoppingCartItem.Amount--;
    //            localAmount = shoppingCartItem.Amount;
    //        }
    //        else
    //        {
    //            _context.ShoppingCartItems.Remove(shoppingCartItem);
    //        }
    //    }

    //    await _context.SaveChangesAsync();
    //}
}
