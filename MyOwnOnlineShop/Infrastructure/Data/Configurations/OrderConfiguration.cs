using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.OrderId);

        // Konfiguracja z nowymi nazwami
        builder.OwnsOne(o => o.DeliveryAddress, address =>
        {
            address.Property(a => a.AddressLine1).HasColumnName("DeliveryAddressLine1");
            address.Property(a => a.AddressLine2).HasColumnName("DeliveryAddressLine2");
            address.Property(a => a.ZipCode).HasColumnName("DeliveryZipCode");
            address.Property(a => a.City).HasColumnName("DeliveryCity");
            address.Property(a => a.State).HasColumnName("DeliveryState");
            address.Property(a => a.Country).HasColumnName("DeliveryCountry");
        });

        builder.OwnsOne(o => o.CustomerContact, contact =>
        {
            contact.Property(c => c.PhoneNumber).HasColumnName("CustomerPhoneNumber");
            contact.Property(c => c.Email).HasColumnName("CustomerEmail");
        });

        builder.OwnsOne(o => o.CustomerInfo, info =>
        {
            info.Property(i => i.FirstName).HasColumnName("CustomerFirstName");
            info.Property(i => i.LastName).HasColumnName("CustomerLastName");
        });

        builder.HasMany(o => o.ProductsList)
            .WithMany(p => p.Orders)
            .UsingEntity(j => j.ToTable("OrderProducts"));
    }
}

