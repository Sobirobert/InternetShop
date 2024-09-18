using MyOwnOnlineShop.Contracts.Request;
using MyOwnOnlineShop_SDK;
using Refit;

namespace MyOwnOnlineShop.Sdk.Sample;

public class Program
{
    public static async Task Main(string[] args)
    {
        var identityApi = RestService.For<IIdentityApi>("https://localhost:44307/");

        //var bloggerApi = RestService.For<IBloggerApi>("https://localhost:44307/", new RefitSettings
        //{
        //    AuthorizationHeaderValueGetter = (request, cancellationToken) => Task.FromResult(cachedToken)
        //    //AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
        //});

        var register = await identityApi.RegisterAsync(new RegisterModel()
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

        //cachedToken = login.Content.Token;

        //var createdPost = await bloggerApi.CreatePostAsync(new CreatePostDto
        //{
        //    Title = "Nowy post SDK",
        //    Content = "Taki testowy post"
        //});

        //var retrievedPost = await bloggerApi.GetPostAsync(createdPost.Content.Data.Id);

        //await bloggerApi.UpdatePostAsync(new UpdatePostDto
        //{
        //    Id = retrievedPost.Content.Data.Id,
        //    Content = "Nowa treść posta SDK"
        //});

        //await bloggerApi.DeletePostAsync(retrievedPost.Content.Data.Id);
    }
}
