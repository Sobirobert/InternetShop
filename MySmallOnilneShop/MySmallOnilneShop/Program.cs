using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.InstallServicesInAssembly(builder.Configuration);
//builder.Host
    //.UseNLog()
    //.UseMetricsWebTracking()
    //.UseMetrics(options =>
    //{
    //    options.EndpointOptions = endpointsOptions =>
    //    {
    //        endpointsOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
    //        endpointsOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
    //        endpointsOptions.EnvironmentInfoEndpointEnabled = false;
    //    };
    //});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
//var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

//try
//{
//    // throw new Exception("Fatal error!");
//    app.Run();
//}
//catch (Exception ex)
//{
//    logger.Fatal(ex, "API stopped.");
//    throw;
//}
//finally
//{
//    LogManager.Shutdown();
//}
