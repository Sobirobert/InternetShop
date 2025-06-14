using Microsoft.AspNetCore.Http;

namespace Application.Services;
public class UserResolverService(IHttpContextAccessor context)
{
    public string GetUser()
    {
        return context.HttpContext.User?.Identity?.Name;
    }
}