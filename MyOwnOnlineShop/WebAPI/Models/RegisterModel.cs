
namespace WebAPI.Models;

public class RegisterModel
{
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string UserNick { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string FlatNumber { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
}