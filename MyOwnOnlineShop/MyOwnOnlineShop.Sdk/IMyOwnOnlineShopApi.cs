using MyOwnOnlineShop.Contracts.Request;
using MyOwnOnlineShop.Contracts.Responses;
using Refit;

namespace MyOwnOnlineShop.Sdk
{
    [Headers("Authorization: Bearer")]
    public interface IMyOwnOnlineShopApi
    {
        [Get("/api/posts/{id}")]
        Task<ApiResponse<Response<ProductDto>>> GetProductAsync(int id);

        [Post("/api/posts")]
        Task<ApiResponse<Response<ProductDto>>> CreateProductAsync(CreateProductDto newProduct);

        [Put("/api/posts")]
        Task UpdateProductAsync(UpdateProductDto updatePost);

        [Delete("/api/posts/{id}")]
        Task DeleteProductAsync(int id);
    }
}
