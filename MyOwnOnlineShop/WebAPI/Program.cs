using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WebAPI.Installers;
using WebAPI.MiddelWares;

namespace WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.InstallServicesInAssembly(builder.Configuration);
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            //app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
        }
        app.UseMiddleware<ErrorHandlingMiddelware>();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.MapHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecksUI();
        //app.UseHealthChecks("/health");

        try
        {
            // throw new Exception("Fatal error!");
            app.Run();
        }
        catch (Exception ex)
        {
            // logger.Fatal(ex, "Application stopped because of exception");
            throw;
        }
        finally
        {
            //LogManager.Shutdown();
        }
    }
}