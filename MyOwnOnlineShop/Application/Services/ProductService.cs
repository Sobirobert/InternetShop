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

    public async Task<IEnumerable<ProductDto>> GetAllProducts(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
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
        var product = _mapper.Map(updateProduct, existingProduct);
        await _productRepository.Update(product);
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _productRepository.GetById(id);
        await _productRepository.Delete(product);
    }
}