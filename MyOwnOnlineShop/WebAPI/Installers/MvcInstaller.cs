using Application;
using Application.Services;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Installers;

public class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration Configuration)
    {
        services.AddApplication();
        services.AddInfrastructure();
        services.AddControllers();
        services.AddAuthorization();
        services.AddTransient<UserResolverService>();

        services.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1, 0);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
            x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
        });
    }
}