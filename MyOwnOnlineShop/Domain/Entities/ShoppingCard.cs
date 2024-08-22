using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("ShoppingCard")]
public class ShoppingCard : AuditableEntity
{
    [Key]
    public int ShoppingCardId { get; set; }

    [Required]
    public List<ShoppingCardItem> ShoppingCardItems { get; set; }
}