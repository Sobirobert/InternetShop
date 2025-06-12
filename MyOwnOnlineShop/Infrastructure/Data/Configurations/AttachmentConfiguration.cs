using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable("Attachments"); 
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Path).IsRequired();
    }
}
