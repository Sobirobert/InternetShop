using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Order")]
public record Order(int OrderId, Guid PublicId, ShippingStatus ShippingStatus, PaymentStatus PaymentStatu, DateTime Created, string? CreatedBy, DateTime? LastModified, 
    string? LastModifiedBy, double TotalPrice, ICollection<Product> ShoppingCardsItems, double OrderTotal, DateTime OrderPlaced) 
    : AuditableEntity(Created, CreatedBy, LastModified, LastModifiedBy)
{
    public record Adress(string AddressLine1, string AddressLine2, string ZipCode, string City, string State, string Country);

    public record Contact(string PhoneNumber, string Email);

    public record PersonalInfo(string FirstName, string LastName);
}


