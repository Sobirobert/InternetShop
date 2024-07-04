using Newtonsoft.Json.Linq;
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
    private int PrivateCategory;
    public int CategoryShowAllDto
    {
        get
        {
            return PrivateCategory;
        }
        set
        {
            value = Products.Count();
            PrivateCategory = value;
        }
    }
    public DateTime CreateDateTime { get; set; } = DateTime.Now;
}