using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(e => e.Id);
        builder.Property(x => x.Price).IsRequired().HasPrecision(3);
        builder.Property(x => x.YearOfProduction).IsRequired();
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(250);
        builder.Property(x => x.LongDescription).IsRequired();
        builder.Property(x => x.Details).IsRequired();
        builder.Property(x => x.LongDescription).IsRequired();
        
        builder.HasMany(w => w.Attachments)
                .WithMany(c => c.Products);
        
        builder.HasMany(w => w.Pictures)
                .WithMany(c => c.Products);

        builder.HasOne(w => w.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(w => w.CategoryId);
        builder.HasMany(p => p.Orders)
            .WithMany(o => o.ProductsList)
            .UsingEntity(j => j.ToTable("OrderProducts"));
    }
}
