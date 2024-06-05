using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public async Task<IEnumerable<ProductDto>> GetAllPostsAsync(/*int pageNumber, int pageSize, string sortField, bool ascending, string filterBy*/)
    {
        var posts = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(posts);
    }

    public async Task<int> GetAllPostsCountAsync(string filterBy)
    {
        return await _productRepository.GetAllCountAsync(filterBy);
    }

    public async Task<ProductDto> GetPostByIdAsync(int id)
    {
        var post = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(post);
    }
    public async Task<ProductDto> AddNewPostAsync(CreateProductDto newProduct, string userId)
    {
        var product = _mapper.Map<Product>(newProduct);
        product.UserId = userId;
        var result = await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDto>(result);
    }
    public async Task UpdatePostAsync(UpdateProductDto updateProduct)
    {
        var existingPost = await _productRepository.GetByIdAsync(updateProduct.Id);
        var post = _mapper.Map(updateProduct, existingPost);
        await _productRepository.UpdateAsync(post);
    }

    public async Task DeletePostAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        await _productRepository.DeleteAsync(product);
    }


    public async Task<bool> UserOwnsPostAsync(int productId, string userId)
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
