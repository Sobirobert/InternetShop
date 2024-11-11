using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProducts(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        _logger.LogDebug("Fetching products");
        _logger.LogInformation($"pageNumber: {pageNumber} | pageSize: {pageSize}");
        var products = await _productRepository.GetAll(pageNumber, pageSize, sortField, ascending, filterBy);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<int> GetAllProductsCount(string filterBy)
    {
        return await _productRepository.GetAllCount(filterBy);
    }

    public async Task<ProductDto> GetProductById(int id)
    {
        var product = await _productRepository.GetById(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> AddNewProduct(CreateProductDto newProduct)
    {
        var product = _mapper.Map<Product>(newProduct);
        var result = await _productRepository.Add(product);
        return _mapper.Map<ProductDto>(result);
    }

    public async Task UpdateProduct(UpdateProductDto updateProduct)
    {
        var existingProduct = await _productRepository.GetById(updateProduct.Id);
        if (existingProduct == null)
        {
            throw new Exception("The product with this id does not exist");
        }
        var product = _mapper.Map(updateProduct, existingProduct);
        await _productRepository.Update(product);
    }

    public async Task DeleteProduct(int id)
    {
        if (id == null)
        {
            throw new Exception("The id couldn't be empty");
        }
        await _productRepository.Delete(id);
    }
}