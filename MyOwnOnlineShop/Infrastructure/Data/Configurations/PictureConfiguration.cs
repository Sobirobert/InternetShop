using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class PictureConfiguration : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> builder)
    {
        builder.ToTable("Pictures");
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Image).IsRequired();
        builder.Property(x => x.Main).IsRequired();
    }
}
