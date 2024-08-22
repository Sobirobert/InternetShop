using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("OrderItem")]
public class OrderItem : AuditableEntity
{
    [Key]
    public int OrderItemId { get; set; }
    
    [Required]
    public string ItemName { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public double Price { get; set; }
}