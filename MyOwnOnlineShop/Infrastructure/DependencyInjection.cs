﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IPictureRepository, PictureRepository>();
        services.AddScoped<IAttachmentRepository<Attachment>, AttachmentRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }
}