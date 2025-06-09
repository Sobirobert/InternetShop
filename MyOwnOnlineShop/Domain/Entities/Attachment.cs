using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Attachments")]
public record Attachment(int Id, string Name, string Path)
{
    public ICollection<Product> Products { get; set; }
}