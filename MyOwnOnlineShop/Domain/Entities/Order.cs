using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using static Domain.Entities.Order;

namespace Domain.Entities;
[Table("Order")]
public record Order(int OrderId, Guid PublicId, ShippingStatus ShippingStatus, PaymentStatus PaymentStatus, double TotalPrice, ICollection<Product> ShoppingCardsItems, 
    DateTime OrderPlaced, Adress DeliveryAddress, Contact CustomerContact, PersonalInfo CustomerInfo)
    : AuditableEntity()
{
    public record Adress(string AddressLine1, string AddressLine2, string ZipCode, string City, string State, string Country);

    public record Contact(string PhoneNumber, string Email);

    public record PersonalInfo(string FirstName, string LastName);
}


