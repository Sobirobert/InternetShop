namespace MySmallOnilneShop.Installers;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration Configuration);
}
