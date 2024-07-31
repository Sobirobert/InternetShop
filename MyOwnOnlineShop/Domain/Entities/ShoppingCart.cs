using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ShoppingCart : AuditableEntity
{
    [Key]
    public int ShoppingCartId { get; set; }

    [Required]
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
}