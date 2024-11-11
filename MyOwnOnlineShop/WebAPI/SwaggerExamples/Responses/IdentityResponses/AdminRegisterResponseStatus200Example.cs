using Swashbuckle.AspNetCore.Filters;
using WebAPI.Wrappers;

namespace WebAPI.SwaggerExamples.Responses.IdentityResponses;
public class AdminRegisterResponseStatus200Example : IExamplesProvider<AdminRegisterResponseStatus200>
{
    public AdminRegisterResponseStatus200 GetExamples()
    {
        return new AdminRegisterResponseStatus200
        {
            Succeeded = true,
            Message = "Admin Created successfully!"
        };
    }
}

public class AdminRegisterResponseStatus200 : Response
{ }