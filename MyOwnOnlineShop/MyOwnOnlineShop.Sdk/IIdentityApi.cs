using MyOwnOnlineShop.Contracts.Request;
using MyOwnOnlineShop.Contracts.Responses;
using Refit;

namespace MyOwnOnlineShop.Sdk;

public interface IIdentityApi
{
    [Post("/api/identity/registerUser")]
    Task<ApiResponse<Response>> RegisterUserAsync([Body] RegisterModel register);

    [Post("/api/identity/registerAdmin")]
    Task<ApiResponse<Response>> RegisterAdminAsync([Body] RegisterModel register);

    [Post("/api/identity/login")]
    Task<ApiResponse<AuthSuccessResponse>> LoginAsync([Body] LoginModel register);

    [Delete("/api/identity/deleteUser")]
    Task<ApiResponse<Response>> DeleteUserAsync(string userId);
}
