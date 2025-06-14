﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class OrderRepository(OnlineShopDBContext context) : IOrderRepository
{
    public async Task<Order> CreateOrder(Order order)
    {
        if(order != null)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return order;
        }
        throw new NullReferenceException();
    }

    public async Task<IEnumerable<Order>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        var query = context.Orders
      .Include(o => o.CustomerContact)         
      .Include(o => o.DeliveryAddress)
      .Include(o => o.CustomerInfo)
      .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filterBy))
        {
            var filter = filterBy.ToLower();

            query = query.Where(o =>
                (o.CustomerInfo != null && (
                    o.CustomerInfo.FirstName.ToLower().Contains(filter) ||
                    o.CustomerInfo.LastName.ToLower().Contains(filter)
                )) ||
                (o.DeliveryAddress != null && (
                    o.DeliveryAddress.AddressLine1.ToLower().Contains(filter) ||
                    o.DeliveryAddress.AddressLine2.ToLower().Contains(filter) ||
                    o.DeliveryAddress.City.ToLower().Contains(filter) ||
                    o.DeliveryAddress.Country.ToLower().Contains(filter) ||
                    o.DeliveryAddress.State.ToLower().Contains(filter) ||
                    o.DeliveryAddress.ZipCode.ToLower().Contains(filter)
                )) ||
                o.PublicId.ToString().Contains(filter) ||
                o.ShippingStatus.ToString().ToLower().Contains(filter) ||
                o.PaymentStatus.ToString().ToLower().Contains(filter)&&                
                (o.CustomerContact != null && (
                    o.CustomerContact.Email.ToString().Contains(filter)||
                    o.CustomerContact.PhoneNumber.ToString().Contains(filter)
                ))
            );
        }

        return await query
            .OrderByPropertyName(sortField, ascending)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetAllCount(string filterBy)
    {
        return await context.Products
            .Where(m => m.Title.ToLower()
            .Contains(filterBy.ToLower()) || m.ShortDescription.ToLower()
            .Contains(filterBy.ToLower()))
            .CountAsync();
    }

    public async Task<Order> GetById(int id)
    {
        var order = await context.Orders
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

        var updatedOrder = order with
        {
            LastModified = DateTime.UtcNow
        };

        context.Orders.Update(updatedOrder);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var order = await context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
        if (order == null)
        {
            throw new Exception("Shopping Card Items aren't exist!");
        }
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }
}