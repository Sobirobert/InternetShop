using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public override string? UserName { get => base.UserName; set => base.UserName = value; }
    public override string? Email { get => base.Email; set => base.Email = value; }
    public string UserSurname { get; set; }
    public string UserNick { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string FlatNumber { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}