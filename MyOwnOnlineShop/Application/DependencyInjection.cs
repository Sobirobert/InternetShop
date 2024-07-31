using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPictureService, PictureService>();
        services.AddScoped<IAttachmentService, AttachmentService>();
        services.AddScoped<IShoppingCartService, ShoppingCartService>();
        services.AddScoped<IShoppingCartItemService, ShoppingCartItemService>();

        return services;
    }
}