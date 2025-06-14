using Application.Services;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data;
public class OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options, UserResolverService userService) : IdentityDbContext<ApplicationUser>(options)
{
    private readonly UserResolverService _userResolverService = userService;

    public DbSet<Product> Products { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

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
        base.OnModelCreating(modelBuilder);
        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
