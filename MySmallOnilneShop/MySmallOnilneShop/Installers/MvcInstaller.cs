
using Application;
using Infrastructure;

namespace MySmallOnilneShop.Installers;

public class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure();
        services.AddApplication();
        services.AddControllers();
    }
}
