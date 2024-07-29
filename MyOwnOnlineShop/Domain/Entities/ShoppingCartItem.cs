using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ShoppingCartItem : AuditableEntity
{
    [Key]
    public int ShoppingCartItemId { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public int ShoppingCartId { get; set; }

    [Required]
    public double Price { get; set; }
}