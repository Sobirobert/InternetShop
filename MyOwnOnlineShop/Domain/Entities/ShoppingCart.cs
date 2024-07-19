
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ShoppingCart
{
    [Key]
    public int ShoppingCartId { get; set; }
    [Required]
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    
}
