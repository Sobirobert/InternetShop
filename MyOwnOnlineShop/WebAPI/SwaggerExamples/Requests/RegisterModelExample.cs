using Swashbuckle.AspNetCore.Filters;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests;

public class RegisterModelExample : IExamplesProvider<RegisterModel>
{
    public RegisterModel GetExamples()
    {
        return new RegisterModel
        {
            NameUser = "yourFirstName",
            UserSurname = "yourSurname",
            UserNick = "yourUniqueNick",
            Email = "yourEmailAdress@example.com",
            Password = "Password123$$",
            Street = "Main street",
            HouseNumber = "3a",
            FlatNumber = "34/8",
            City = "Warsaw",
            PostalCode = "88-200",
            Country = "Poland",
            PhoneNumber = "123456789"
        };
    }
}