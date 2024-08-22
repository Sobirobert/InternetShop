using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OnlineShopDBContext _context;

    public OrderRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        return await _context.Orders
            .Where(m => m.OrderDetail.Email.ToLower().Contains(filterBy.ToLower()) 
            || m.OrderDetail.FirstName.ToLower().Contains(filterBy.ToLower()) 
            || m.OrderDetail.LastName.ToLower().Contains(filterBy.ToLower())
            || m.OrderDetail.AddressLine1.ToLower().Contains(filterBy.ToLower())
            || m.OrderDetail.AddressLine2.ToLower().Contains(filterBy.ToLower())
            || m.OrderDetail.City.ToLower().Contains(filterBy.ToLower())
            || m.OrderDetail.Country.ToLower().Contains(filterBy.ToLower())
            || m.OrderDetail.PhoneNumber.ToLower().Contains(filterBy.ToLower())
            )
            .OrderByPropertyName(sortField, ascending)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Order> GetById(int id)
    {
        var order = await _context.Orders
            .SingleOrDefaultAsync(x => x.OrderId == id);
        if (order == null)
        {
            throw new Exception("Shopping Card Items aren't exist!");
        }
        return order;
    }

    public async Task<Order> Add(Order order)
    {
        if (order == null)
        {
            throw new Exception("Shopping Card Items aren't exist!");
        }
        order.Created = DateTime.Now;
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task Update(Order order)
    {
        if (order == null)
        {
            throw new Exception("Shopping Card Items aren't exist!");
        }
        order.LastModified = DateTime.Now;
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var order = _context.Orders.FirstOrDefault(x => x.OrderId == id);
        if (order == null)
        {
            throw new Exception("Shopping Card Items aren't exist!");
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    //public async Task<IEnumerable<ShoppingCartItem>> CreateOrder(OrderUserDetails order, int shoppingCartID)
    //{
    //    order.OrderPlaced = DateTime.Now;
    //    var shoppingCartItems = _shoppingCart.ShoppingCartItems;
    //    order.OrderTotal = await _shoppingCart.GetShoppingCartTotalAsync(shoppingCartID);
    //    order.OrderDetails = new List<Order>();

    //    foreach (var shoppingCartItem in shoppingCartItems)
    //    {
    //        var orderDetail = new Order
    //        {
    //            Amount = shoppingCartItem.Amount,
    //            ProductId = shoppingCartItem.Product.Id,
    //            Price = shoppingCartItem.Product.Price
    //        };

    //        order.OrderDetails.Add(orderDetail);
    //    }

    //    await _context.Orders.AddAsync(order);

    //    await _context.SaveChangesAsync();
    //    var orderList = await _shoppingCart.GetShoppingCartItemsAsync(shoppingCartID);
    //    return orderList;
    //}
}