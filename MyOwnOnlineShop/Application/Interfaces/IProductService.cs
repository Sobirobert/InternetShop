using Application.Dto;

namespace Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllPostsAsync(/*int pageNumber, int pageSize, string sortField, bool ascending, string filterBy*/);

    Task<int> GetAllPostsCountAsync(string filterBy);

    Task<ProductDto> GetPostByIdAsync(int id);

    Task<ProductDto> AddNewPostAsync(CreateProductDto newProduct, string userId);

    Task UpdatePostAsync(UpdateProductDto updateProduct);

    Task DeletePostAsync(int id);

    Task<bool> UserOwnsPostAsync(int productId, string userId);
}