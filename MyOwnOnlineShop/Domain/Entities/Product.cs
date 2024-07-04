using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Products")]
public class Product : AuditableEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string ShortDescription { get; set; }

    [Required]
    public string LongDescription { get; set; }

    [Required]
    public string Details { get; set; }

    [Required]
    public int YearOfProduction { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    public bool IsProductOfTheWeek { get; set; }
    [Required]
    public Enums.Type Type { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public Category Category { get; set; }

    public ICollection<Picture> Pictures { get; set; }
    public ICollection<Attachment> Attachments { get; set; }

}