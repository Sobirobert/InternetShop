using Domain.Common;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Order")]
public class Order : AuditableEntity
{
    [Key]
    public int OrderId { get; set; }
    [Required]
    public ShippingStatus ShippingStatus { get; set; }
    [Required]
    public PaymentStatus PaymentStatus { get; set; }
    [Required]
    public double TotalPrice { get; set; }
    [Required]
    public List<OrderItem> ShoppingCardsItems { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string AddressLine1 { get; set; }

    [Required]
    public string AddressLine2 { get; set; }

    [Required]
    public string ZipCode { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string State { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string Email { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public double OrderTotal { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public DateTime OrderPlaced { get; set; }
}