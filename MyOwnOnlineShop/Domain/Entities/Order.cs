using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Order")]
public class Order : AuditableEntity
{
    [Key]
    public int OrderId { get; set; }
    [Required]
    public int OrderDetailId { get; set; }
    [Required]
    public int ShoppingCartId { get; set; } 
    [Required]
    public bool  IsPaid { get; set; }
    [Required]
    public bool IsSend { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public List<ShoppingCardItem> ShoppingCardsItems { get; set; }
    [Required]
    public OrderUserDetails OrderUserDetails { get; set; }
}