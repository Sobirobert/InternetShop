using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;
public record Order(int OrderId, Guid PublicId, ShippingStatus ShippingStatus, PaymentStatus PaymentStatus, double TotalPrice, 
    DateTime OrderPlaced)
    : AuditableEntity()
{

    public Adress? DeliveryAddress { get; init; }
    public Contact? CustomerContact { get; init; }
    public PersonalInfo? CustomerInfo { get; init; }
    public ICollection<Product> ProductsList { get; init; } = new List<Product>();
    public record Adress(string AddressLine1, string AddressLine2, string ZipCode, string City, string State, string Country);

    public record Contact(string PhoneNumber, string Email);

    public record PersonalInfo(string FirstName, string LastName);
}


