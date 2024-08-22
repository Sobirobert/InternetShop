using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderUserDetailsRepository : IOrderUserDetailsRepository
{
    private readonly OnlineShopDBContext _context;

    public OrderUserDetailsRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderUserDetails>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        return await _context.OrderUsersDetails
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

    public async Task<OrderUserDetails> GetById(int id)
    {
        var details = await _context.OrderUsersDetails
            .SingleOrDefaultAsync(x => x.OrderUserDetailsId == id);
        if (details == null)
        {
            throw new Exception("Shopping Card Items aren't exist!");
        }
        return details;
    }

    public async Task<OrderUserDetails> Add(OrderUserDetails orderDetails)
    {
        if (orderDetails == null)
        {
            throw new Exception("Shopping Card Items aren't exist!");
        }
        orderDetails.Created = DateTime.Now;
        await _context.OrderUsersDetails.AddAsync(orderDetails);
        await _context.SaveChangesAsync();
        return orderDetails;
    }

    public async Task Update(OrderUserDetails orderDetails)
    {
        if (orderDetails == null)
        {
            throw new Exception("Shopping Card Items aren't exist!");
        }
        orderDetails.LastModified = DateTime.Now;
        _context.OrderUsersDetails.Update(orderDetails);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var details = _context.OrderUsersDetails.FirstOrDefault(x => x.OrderUserDetailsId == id);
        if (details == null)
        {
            throw new Exception("Shopping Card Items aren't exist!");
        }
        _context.OrderUsersDetails.Remove(details);
        await _context.SaveChangesAsync();
    }
}
