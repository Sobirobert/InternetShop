using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.OrderId);
        builder.Property(x => x.ShippingStatus).IsRequired();
        builder.Property(x => x.TotalPrice).IsRequired().HasPrecision(3);
        builder.Property(x => x.ShoppingCardsItems).IsRequired();
        builder.HasMany(x => x.ShoppingCardsItems)
            .WithMany(x => x.Orders);
    }
}
