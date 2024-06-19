using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        var products = await _productRepository.GetAllAsync(pageNumber, pageSize, sortField, ascending, filterBy);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<int> GetAllProductsCountAsync(string filterBy)
    {
        return await _productRepository.GetAllCountAsync(filterBy);
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> AddNewProductAsync(CreateProductDto newProduct, string userId)
    {
        var product = _mapper.Map<Product>(newProduct);
        product.UserId = userId;
        var result = await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDto>(result);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProduct)
    {
        var existingProduct = await _productRepository.GetByIdAsync(updateProduct.Id);
        var product = _mapper.Map(updateProduct, existingProduct);
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        await _productRepository.DeleteAsync(product);
    }

    public async Task<bool> UserOwnsProductAsync(int productId, string userId)
    {
        var product = await _productRepository.GetByIdAsync(productId);

        if (product == null)
        {
            return false;
        }

        if (product.UserId != userId)
        {
            return false;
        }

        return true;
    }
}