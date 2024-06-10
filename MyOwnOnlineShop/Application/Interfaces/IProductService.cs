using Application.Dto;

namespace Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync(int pageNumber, int pageSize/*, string sortField, bool ascending, string filterBy*/);

    Task<int> GetAllProductsCountAsync(/*string filterBy*/);

    Task<ProductDto> GetProductByIdAsync(int id);

    Task<ProductDto> AddNewProductAsync(CreateProductDto newProduct);

    Task UpdateProductAsync(UpdateProductDto updateProduct);

    Task DeleteProductAsync(int id);

    Task<bool> UserOwnsProductAsync(int productId, string userId);
}