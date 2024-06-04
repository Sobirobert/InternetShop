﻿using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        //services.AddScoped<ICosmosPostRepository, CosmosPostRepository>();
        // services.AddScoped<IPictureRepository, PictureRepository>();
        //services.AddScoped<IAttachmentRepository, AttachmentRepository>();

        return services;
    }
}

