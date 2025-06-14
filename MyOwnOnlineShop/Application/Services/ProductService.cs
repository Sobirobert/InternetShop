using Application.Dto.ProductDtoFolder;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services;
public class ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetAllProducts(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        logger.LogDebug("Fetching products");
        logger.LogInformation($"pageNumber: {pageNumber} | pageSize: {pageSize}");
        var products = await productRepository.GetAll(pageNumber, pageSize, sortField, ascending, filterBy);
        return mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<int> GetAllProductsCount(string filterBy)
    {
        return await productRepository.GetAllCount(filterBy);
    }

    public async Task<ProductDto> GetProductById(int id)
    {
        var product = await productRepository.GetById(id);
        return mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> AddNewProduct(CreateProductDto newProduct)
    {
        var product = mapper.Map<Product>(newProduct);
        var result = await productRepository.Add(product);
        return mapper.Map<ProductDto>(result);
    }

    public async Task UpdateProduct(UpdateProductDto updateProduct)
    {
        var existingProduct = await productRepository.GetById(updateProduct.Id);
        if (existingProduct == null)
        {
            throw new Exception("The product with this id does not exist");
        }
        var product = mapper.Map(updateProduct, existingProduct);
        await productRepository.Update(product);
    }

    public async Task DeleteProduct(int id)
    {
        if (id == null)
        {
            throw new Exception("The id couldn't be empty");
        }
        await productRepository.Delete(id);
    }
}