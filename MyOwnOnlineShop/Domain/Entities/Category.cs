using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public List<Product> Products { get; set; }
    public DateTime CreateDateTime { get; set; } = DateTime.Now;
}