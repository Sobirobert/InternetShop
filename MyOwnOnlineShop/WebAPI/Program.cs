using HealthChecks.UI.Client;
using Infrastructure.Data;
using InternetShop.WebAPI.GlobalExceptionHandling;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
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
        builder.Host.UseNLog();
        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args);
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
            });
        }
        app.UseMiddleware<ErrorHandlingMiddelware>();
        app.UseHttpsRedirection();
        app.UseGlobalExceptionHandler();
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
        var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        try
        {
            app.Run();
        }
        catch (Exception ex)
        {
            logger.Fatal(ex, "Application stopped because of exception");
            throw;
        }
        finally
        {
            NLog.LogManager.Shutdown();
        }
    }
}