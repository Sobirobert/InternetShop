using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _postRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _postRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public Task<int> GetAllProductsCountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var product = await _postRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(product);   
    }
}
