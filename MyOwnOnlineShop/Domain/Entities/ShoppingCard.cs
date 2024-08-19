using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ShoppingCard 
{
    [Key]
    public int ShoppingCardId { get; set; }

    [Required]
    public List<ShoppingCardItem> ShoppingCardItems { get; set; }
}