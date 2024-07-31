using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class ShoppingCartItem : AuditableEntity
{
    [Key]
    public int ShoppingCartItemId { get; set; }

    [Required]
    public int Amount { get; set; }

    [ForeignKey("ShoppingCartId")]
    public ShoppingCart ShoppingCart { get; set; }

    [Required]
    public double Price { get; set; }
}