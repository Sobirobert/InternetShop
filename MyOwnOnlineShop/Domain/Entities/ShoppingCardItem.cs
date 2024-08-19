using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class ShoppingCardItem 
{
    [Key]
    public int ShoppingCardItemId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int Amount { get; set; }

    //public ShoppingCard ShoppingCard { get; set; }

    [ForeignKey("ShoppingCard" + "Id")]
    public int ShoppingCardId { get; set; }

    [Required]
    public double Price { get; set; }
}