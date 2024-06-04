using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Product")]
public class Product : AuditableEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(5)]
    public string Title { get; set; }

    [Required]
    [MaxLength(2000)]
    public string DescriptionOfProduct { get; set; }

    [MinLength(4)]
    [Required]
    public int YearOfProduction { get; set; }
    
    [Required]
    public double Price { get; set; }

    [Required]
    [MaxLength(450)]
    public string UserId { get; set; }

    [Required]
    public Enums.Type Type { get; set; }

    [Required]
    public Category Category { get; set; }

    public ICollection<Picture> Pictures { get; set; }
    public ICollection<Attachment> Attachments { get; set; }

    public Product()
    { }

    public Product(int id, string title, string descriptionOfProduct)
    {
        Id = id;
        Title = title;
        DescriptionOfProduct = descriptionOfProduct;
    }

    public Product(int id, string title, string descriptionOfProduct, int yearOfProduction)
    {
        Id = id;
        Title = title;
        DescriptionOfProduct = descriptionOfProduct;
        YearOfProduction = yearOfProduction;
    }
    public Product(Category categpry,int id, string title, string descriptionOfProduct, int yearOfProduction, Enums.Type type, double price)
    {
        Category = categpry;
        Id = id;
        Type = type;
        YearOfProduction = yearOfProduction;
        Title = title;
        DescriptionOfProduct = descriptionOfProduct;
        Price = price;
    }
}