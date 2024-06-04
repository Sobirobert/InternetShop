
using Application;
using Infrastructure;

namespace WebAPI.Installers;

public class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration Configuration)
    {
        services.AddApplication();
        services.AddInfrastructure();

        //var metrics = AppMetrics.CreateDefaultBuilder().Build();
        //services.AddMetrics(metrics);

        //services.AddMemoryCache();

        services.AddControllers();
            //.AddFluentValidation(options =>
            //{
            //    options.RegisterValidatorsFromAssemblyContaining<CreatePostDtoValidator>();
            //})
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.WriteIndented = true;
            //})
            //.AddXmlSerializerFormatters();

        services.AddAuthorization();

        //services.AddTransient<UserResolverService>();
        //services.AddScoped<ErrorHandlingMiddelware>();

        //services.AddApiVersioning(x =>
        //{
        //    x.DefaultApiVersion = new ApiVersion(1, 0);
        //    x.AssumeDefaultVersionWhenUnspecified = true;
        //    x.ReportApiVersions = true;
        //    x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
        //});
    }
}
