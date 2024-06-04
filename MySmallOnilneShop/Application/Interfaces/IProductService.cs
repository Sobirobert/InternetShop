using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();

    Task<int> GetAllProductsCountAsync();

    Task<ProductDto> GetProductByIdAsync(int id);

    //Task<PostDto> AddNewPostAsync(CreatePostDto newPost, string userId);

    //Task UpdatePostAsync(UpdatePostDto updatePost);

    //Task DeletePostAsync(int id);

    //Task<bool> UserOwnsPostAsync(int postId, string userId);
}
