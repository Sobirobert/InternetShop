using Swashbuckle.AspNetCore.Filters;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests;
public class OrderModelExample : IExamplesProvider<OrderModel>
{
    public OrderModel GetExamples()
    {
        return new OrderModel
        {
            FirstName = "Mike",
            LastName = "Kowalski",
            AddressLine1 = "Great Street 7",
            AddressLine2 = "Flat 53/38",
            ZipCode = "66622",
            City = "Warszawa",
            State = "Łódzkie",
            Country = "Poland",
            PhoneNumber = "222111444",
            Email = "johnsnow@gmail.com"
        };
    }
}
