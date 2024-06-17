using Swashbuckle.AspNetCore.Filters;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests;

public class RegisterModelExample : IExamplesProvider<RegisterModel>
{
    public RegisterModel GetExamples()
    {
        return new RegisterModel
        {
            UserName = "yourFirstName",
            UserSurname = "yourSurname",
            UserNick = "yourUniqueNick",
            Email = "yourEmailAdress@example.com",
            PhoneNumber = "123456789",
            Password = "Password123$$",
            Street = "Main street",
            HouseNumber = "3a",
            FlatNumber = "34/8",
            City = "Warsaw",
            PostalCode = "88-200",
            Country = "Poland"
        };
    }
}