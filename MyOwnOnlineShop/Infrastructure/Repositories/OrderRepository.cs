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
    public async Task<Order> CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;
        order.ShippingStatus = 0;
        order.PaymentStatus = 0;
        order.OrderTotal = 0;
        order.TotalPrice = 0;
        order.CreatedBy = $"{order.FirstName} {order.LastName}";
        order.LastModified = DateTime.Now;
        order.ShoppingCardsItems = new List<OrderItem>();
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task AddToOrder(int orderId, int amount, int productId)
    {
        var order = await _context.Orders
            .SingleOrDefaultAsync(s => s.OrderId == orderId);
        if (order == null)
        {
            throw new ArgumentException("Order isn't exist!");
        }

        var product = await _context.Products
            .SingleOrDefaultAsync(s => s.Id == productId);
        if (product == null)
        {
            throw new ArgumentException("Product isn't exist!");
        }

        var orderItem = new OrderItem
        {
            ItemName = product.Title,
            ProductId = productId,
            OrderId = orderId,
            Amount = amount,
            Price = product.Price,
        };

        order.ShoppingCardsItems.Add(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        return await _context.Orders
            .Where(m => m.Email.ToLower().Contains(filterBy.ToLower())
            || m.FirstName.ToLower().Contains(filterBy.ToLower())
            || m.LastName.ToLower().Contains(filterBy.ToLower())
            || m.AddressLine1.ToLower().Contains(filterBy.ToLower())
            || m.AddressLine2.ToLower().Contains(filterBy.ToLower())
            || m.City.ToLower().Contains(filterBy.ToLower())
            || m.Country.ToLower().Contains(filterBy.ToLower())
            || m.PhoneNumber.ToLower().Contains(filterBy.ToLower())
            )
            .OrderByPropertyName(sortField, ascending)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<int> GetAllCount(string filterBy)
    {
        return await _context.Products
            .Where(m => m.Title.ToLower()
            .Contains(filterBy.ToLower()) || m.ShortDescription.ToLower()
            .Contains(filterBy.ToLower()))
            .CountAsync();
    }

    public async Task<double> GetOrdersTotal(int orderId)
    {
        var total = await _context.Orders
            .Where(c => c.OrderId == orderId)
            .SelectMany(c => c.ShoppingCardsItems)
            .SumAsync(p => p.Price * p.Amount);
        return total;
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
}