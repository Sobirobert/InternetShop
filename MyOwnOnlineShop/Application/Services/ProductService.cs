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

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(int pageNumber, int pageSize/*, string sortField, bool ascending, string filterBy*/)
    {
        var posts = await _productRepository.GetAllAsync(pageNumber, pageSize);
        return _mapper.Map<IEnumerable<ProductDto>>(posts);
    }

    public async Task<int> GetAllProductsCountAsync(/*string filterBy*/)
    {
        return await _productRepository.GetAllCountAsync(/*filterBy*/);
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var post = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(post);
    }

    public async Task<ProductDto> AddNewProductAsync(CreateProductDto newProduct)
    {
        var product = _mapper.Map<Product>(newProduct);
        var result = await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDto>(result);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProduct)
    {
        var existingPost = await _productRepository.GetByIdAsync(updateProduct.Id);
        var post = _mapper.Map(updateProduct, existingPost);
        await _productRepository.UpdateAsync(post);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        await _productRepository.DeleteAsync(product);
    }

    public async Task<bool> UserOwnsProductAsync(int productId, string userId)
    {
        var post = await _productRepository.GetByIdAsync(productId);

        if (post == null)
        {
            return false;
        }

        if (post.UserId != userId)
        {
            return false;
        }

        return true;
    }
}