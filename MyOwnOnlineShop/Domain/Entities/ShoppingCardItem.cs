using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("ShoppingCardItem")]
public class ShoppingCardItem : AuditableEntity
{
    [Key]
    public int ShoppingCardItemId { get; set; }
    
    [Required]
    public string ItemName { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int ShoppingCardId { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public double Price { get; set; }

    public ShoppingCard ShoppingCard { get; set; }
}