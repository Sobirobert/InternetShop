using Application.Dto.ProductDtoFolder;

namespace Application.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProducts(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);

    Task<int> GetAllProductsCount(string filterBy);

    Task<ProductDto> GetProductById(int id);

    Task<ProductDto> AddNewProduct(CreateProductDto newProduct);

    Task UpdateProduct(UpdateProductDto updateProduct);

    Task DeleteProduct(int id);
}