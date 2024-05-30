
using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities;

[Table("Products")]
public class Product : AuditableEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(5)]
    [NotNull]
    public string Title { get; set; }

    [Required]
    [NotNull]
    [MaxLength(100)]
    public double Price { get; set; }

    [Required]
    [MaxLength(2000)]
    public string Description { get; set; }

    [Required]
    [MaxLength(4)]
    public int YearOfProduction { get; set; }
    
    [Required]
    [NotNull]
    public Enums.Type Type {get; set; }

    [Required]
    [NotNull]
    public Category Category { get; set; }

    public ICollection<Picture> Pictures { get; set; }
    public ICollection<Attachment> Attachments { get; set; }

    public Product()
    { }
    public Product(int id, string title, string description, double price, Enums.Type type, Category category)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Type = type;
        Category = category;
    }

    public Product(int id, string title, string description, double price, int yearOfProduction, Enums.Type type, Category category)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        YearOfProduction = yearOfProduction;
        Type = type;
        Category = category;
    }
}
