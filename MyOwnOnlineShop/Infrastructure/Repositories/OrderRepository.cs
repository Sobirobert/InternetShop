using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class OrderRepository //: IOrderRepository
{
    private readonly OnlineShopDBContext _context;
    private readonly ShoppingCartRepository _shoppingCart;

    public OrderRepository(OnlineShopDBContext context, ShoppingCartRepository shoppingCart)
    {
        _context = context;
        _shoppingCart = shoppingCart;
    }

    //public async Task<List<ShoppingCartItem>> CreateOrder(Order order)
    //{
    //    order.OrderPlaced = DateTime.Now;
    //    var shoppingCartItems = _shoppingCart.ShoppingCartItems;
    //    order.OrderTotal = await _shoppingCart.GetShoppingCartTotalAsync();
    //    order.OrderDetails = new List<OrderDetail>();

    //    foreach (var shoppingCartItem in shoppingCartItems)
    //    {
    //        var orderDetail = new OrderDetail
    //        {
    //            Amount = shoppingCartItem.Amount,
    //            ProductId = shoppingCartItem.Product.Id,
    //            Price = shoppingCartItem.Product.Price
    //        };

    //        order.OrderDetails.Add(orderDetail);
    //    }

    //    await _context.Orders.AddAsync(order);

    //    await _context.SaveChangesAsync();
    //    var orderList = await _shoppingCart.GetShoppingCartItemsAsync();
    //    return orderList;
    //}
}
