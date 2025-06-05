using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Entities.Order;

namespace Infrastructure.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Adress>
{
    public void Configure(EntityTypeBuilder<Adress> builder)
    {
        builder.HasNoKey();
    }
}
