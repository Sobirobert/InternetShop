﻿using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //services.AddScoped<IProductService, ProductService>();
        //services.AddScoped<ICosmosPostService, CosmosPostService>();
        //services.AddScoped<IPictureService, PictureService>();
        //services.AddScoped<IAttachmentService, AttachmentService>();

        return services;
    }
}
