using Application.Dto;

namespace Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<PostDto>> GetAllPostsAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);

    Task<int> GetAllPostsCountAsync(string filterBy);

    Task<PostDto> GetPostByIdAsync(int id);

    Task<PostDto> AddNewPostAsync(CreateProductDto newPost, string userId);

    Task UpdatePostAsync(UpdateProductDto updatePost);

    Task DeletePostAsync(int id);

    Task<bool> UserOwnsPostAsync(int postId, string userId);
}