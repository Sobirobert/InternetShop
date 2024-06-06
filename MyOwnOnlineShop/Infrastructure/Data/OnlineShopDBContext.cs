using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class OnlineShopDBContext : DbContext
{
    public OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options) 
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}