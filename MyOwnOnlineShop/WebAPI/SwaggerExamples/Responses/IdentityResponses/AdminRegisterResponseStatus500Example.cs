using Swashbuckle.AspNetCore.Filters;
using WebAPI.Wrappers;

namespace WebAPI.SwaggerExamples.Responses.IdentityResponses;
public class AdminRegisterResponseStatus500Example : IExamplesProvider<AdminRegisterResponseStatus500>
{
    public AdminRegisterResponseStatus500 GetExamples()
    {
        return new AdminRegisterResponseStatus500
        {
            Succeeded = false,
            Message = "Admin already exists!"
        };
    }
}

public class AdminRegisterResponseStatus500 : Response
{ }