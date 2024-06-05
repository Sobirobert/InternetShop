using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

namespace Infrastructure.Data;

public class OnlineShopContext : DbContext
{
    public OnlineShopContext(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    //public DbSet<Picture> Pictures { get; set; }
    //public DbSet<Attachment> Attachments { get; set; }
}
