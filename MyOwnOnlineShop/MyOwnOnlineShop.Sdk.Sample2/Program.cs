using MyOwnOnlineShop.Contracts.Enums;
using MyOwnOnlineShop.Contracts.Request;
using Refit;

namespace MyOwnOnlineShop.Sdk.Sample;

public class Program
{
    public static async Task Main(string[] args)
    {
        var cachedToken = string.Empty;
        var identityApi = RestService.For<IIdentityApi>("https://localhost:44307/");

        var onlineShopApi = RestService.For<IMyOwnOnlineShopApi>("https://localhost:44307/", new RefitSettings
        {
            AuthorizationHeaderValueGetter = (request, cancellationToken) => Task.FromResult(cachedToken)
        });

        var register = await identityApi.RegisterAdminAsync(new RegisterModel()
        {
            Email = "sdkacccount@gmail.com",
            Username = "sdkaccount",
            Password = "Pa$$wOrd123!"
        });

        var login = await identityApi.LoginAsync(new LoginModel()
        {
            Username = "sdkaccount",
            Password = "Pa$$wOrd123!"
        });

        cachedToken = login.Content.Token;

        var createdProduct = await onlineShopApi.CreateProductAsync(new CreateProductDto
        {
            Title = "Nowy Produkt SDK",
            ShortDescription = "Taki testowy produkt",
            LongDescription = "Długi opis",
            Details = "25 cm szerokość, 20 cm długość",
            YearOfProduction = 2024,
            Amount = 1,
            Price = 20,
            IsProductOfTheWeek = false,
            TypeProduct = (TypeProduct)2,
            CategoryId = 1,
        });

        var retrievedProduct = await onlineShopApi.GetProductAsync(createdProduct.Content.Data.Id);

        await onlineShopApi.UpdateProductAsync(new UpdateProductDto
        {
            Id = retrievedProduct.Content.Data.Id,
            Title = "Nowy Produkt SDK Super Okazja",
            ShortDescription = "Taki testowy produkt 2 ",
            LongDescription = "Długi opis zmieniony",
            Details = "25 cm szerokość, 20 cm długość i 30 cm wysokości",
            YearOfProduction = 2024,
            Amount = 1,
            Price = 20,
            IsProductOfTheWeek = true,
            TypeProduct = (TypeProduct)2,
        });

        await onlineShopApi.DeleteProductAsync(retrievedProduct.Content.Data.Id);
    }
}




