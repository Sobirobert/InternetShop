﻿using Application;
using Application.Services;
using Application.Validators.ProductDto;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using WebAPI.MiddelWares;

namespace WebAPI.Installers;

public class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration Configuration)
    {
        services.AddApplication();
        services.AddInfrastructure();
        services.AddControllers()
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<CreateProductDtoValidator>();
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            })
            .AddXmlSerializerFormatters();

        services.AddAuthorization();
        services.AddTransient<UserResolverService>();
        services.AddRazorPages();
        services.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1, 0);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
            x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
        });

        services.AddScoped<ErrorHandlingMiddelware>();
    }
}