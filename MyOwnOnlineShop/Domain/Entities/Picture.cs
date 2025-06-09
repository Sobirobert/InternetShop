using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Pictures")]
public record Picture (int Id, string Name, byte[] Image, bool Main)
{
    public ICollection<Product> Products { get; set; }
}