using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Attachments")]
public class Attachment
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(200)]
    public string Path { get; set; }

    [Required]
    public int UserId { get; set; }

    public ICollection<Product> Products { get; set; }
}