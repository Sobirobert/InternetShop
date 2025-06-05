using Application.Services;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data;
public class OnlineShopDBContext : IdentityDbContext<ApplicationUser>
{
    private readonly UserResolverService _userResolverService;

    public OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options, UserResolverService userService)
        : base(options)
    {
        _userResolverService = userService;
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        var entries = ChangeTracker
               .Entries()
               .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((AuditableEntity)entityEntry.Entity).LastModified = DateTime.UtcNow;
            ((AuditableEntity)entityEntry.Entity).LastModifiedBy = _userResolverService.GetUser();

            if (entityEntry.State == EntityState.Added)
            {
                ((AuditableEntity)entityEntry.Entity).Created = DateTime.UtcNow;
                ((AuditableEntity)entityEntry.Entity).CreatedBy = _userResolverService.GetUser();
            }
        }
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        modelBuilder.Entity<Product>()
            .HasAlternateKey(e => e.Id);

        modelBuilder.Entity<Attachment>()
            .HasAlternateKey(e => e.Id);

        modelBuilder.Entity<Order>()
            .HasAlternateKey(e => e.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasAlternateKey(e => e.OrderItemId);

        modelBuilder.Entity<Picture>()
            .HasAlternateKey(e => e.Id);

        modelBuilder.Entity<Category>()
            .HasAlternateKey(e => e.Id);

        modelBuilder.Entity<Product>(eb =>
        {
            eb.Property(x => x.Price).IsRequired().HasPrecision(3);
            eb.Property(x => x.YearOfProduction).IsRequired();
            eb.Property(x => x.Title).IsRequired();
            eb.Property(x => x.ShortDescription).IsRequired().HasMaxLength(250);
            eb.Property(x => x.LongDescription).IsRequired();
            eb.Property(x => x.Details).IsRequired();
            eb.Property(x => x.LongDescription).IsRequired();
            eb.HasMany(w => w.Attachments)
                .WithMany(c => c.Products);

            eb.HasMany(w => w.Pictures)
                .WithMany(c => c.Products);

            eb.HasMany(w => w.OrderItems)
                .WithMany(c => c.Products);
        });

        modelBuilder.Entity<Attachment>(eb =>
        {
            eb.Property(x => x.Name).IsRequired();
            eb.Property(x => x.Path).IsRequired();
            eb.Property(x => x.UserId).IsRequired();
        });

        modelBuilder.Entity<Category>(eb =>
        {
            eb.Property(x => x.CategoryName).IsRequired();
            eb.Property(x => x.Description).IsRequired();
            eb.Property(x => x.TotalRecords).IsRequired();

            eb.HasMany(x => x.products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
            
        });

        modelBuilder.Entity<Order>(eb =>
        {
            eb.Property(x => x.ShippingStatus).IsRequired();
            eb.Property(x => x.PaymentStatus).IsRequired();
            eb.Property(x => x.TotalPrice).IsRequired().HasPrecision(3);
            eb.Property(x => x.ShoppingCardsItems).IsRequired();
            eb.Property(x => x.FirstName).IsRequired();
            eb.Property(x => x.AddressLine1).IsRequired();
            eb.Property(x => x.AddressLine2).IsRequired();
            eb.Property(x => x.ZipCode).IsRequired();
            eb.Property(x => x.City).IsRequired();
            eb.Property(x => x.State).IsRequired();
            eb.Property(x => x.Country).IsRequired();
            eb.Property(x => x.PhoneNumber).IsRequired();
            eb.Property(x => x.Email).IsRequired();
            eb.HasMany(x => x.ShoppingCardsItems)
            .WithMany(x => x.Orders);
        });

        modelBuilder.Entity<Picture>(eb =>
        {
            eb.Property(x => x.Name).IsRequired();
            eb.Property(x => x.Image).IsRequired();
            eb.Property(x => x.Main).IsRequired();
        });

        modelBuilder.Entity<OrderItem>(eb =>
        {
            eb.Property(x => x.OrderItemId).IsRequired();
            eb.Property(x => x.Price).IsRequired();
        });
    }
}