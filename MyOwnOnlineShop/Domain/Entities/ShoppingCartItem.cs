using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class ShoppingCartItem
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
