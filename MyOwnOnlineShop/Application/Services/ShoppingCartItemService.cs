using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
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

public class ShoppingCartItemService : IShoppingCartItemService
{
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ShoppingCartItemService(IShoppingCartRepository shoppingCartRepository, IShoppingCartItemRepository shoppingCartItemRepository, IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _shoppingCartRepository = shoppingCartRepository;
        _productRepository = productRepository;
    }

    public async Task<ShoppingCartItemDto> GetShoppingCartItemById(int id)
    {
        var item = await _shoppingCartItemRepository.GetById(id);
        return _mapper.Map<ShoppingCartItemDto>(item);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProducts(int shoppingCartId)
    {
        var shoppingCart = await _shoppingCartRepository.GetById(shoppingCartId);
        if (shoppingCart != null)
        {
            throw new Exception("Shopping cart isn't exist.");
        }

        var shoppingCartItems = await _shoppingCartRepository.GetAlltems(shoppingCartId);
        if (shoppingCartItems != null)
        {
            throw new Exception("List items from shopping cart are empty.");
        }

        List<Product> productList = new List<Product>();
        foreach (var item in shoppingCartItems)
        {
            var product = await _productRepository.GetById(item.ShoppingCartItemId);
            productList.Add(product);
        }
        var result = _mapper.Map<IEnumerable<ProductDto>>(productList);
        return result;
    }

    public async Task<IEnumerable<ShoppingCartItemDto>> GetAllShoppingCartItems(int shoppingCartId)
    {
        var shoppingCartItem = await _shoppingCartRepository.GetAlltems(shoppingCartId);
        if (shoppingCartItem != null)
        {
            throw new Exception("List items from shopping cart are empty.");
        }
        return _mapper.Map<IEnumerable<ShoppingCartItemDto>>(shoppingCartItem);
    }

    public async Task<CreateShoppingCartItemDto> AddNewShoppingCartItem(int idProduct)
    {
        var Product = await _productRepository.GetById(idProduct);
        if (Product != null)
        {
            throw new Exception("Product isn't exist!");
        }
        var newProduct = await _shoppingCartItemRepository.Add(idProduct);
        return _mapper.Map<CreateShoppingCartItemDto>(newProduct);
    }

    public async Task UpdateShioppingCartItem(ShoppingCartItemDto shoppingCartItem)
    {
        var existingProduct = await _shoppingCartItemRepository.GetById(shoppingCartItem.ShoppingCartItemId);
        if (existingProduct != null)
        {
            throw new Exception("There is not product on this Id.");
        }
        var product = _mapper.Map(shoppingCartItem, existingProduct);
        await _shoppingCartItemRepository.Update(product);
    }

    public async Task DeleteShioppingCartItem(int shoppingCartItemId)
    {
        var product = await _shoppingCartItemRepository.GetById(shoppingCartItemId);
        if (product != null)
        {
            throw new Exception("There is not product on this Id.");
        }
        await _shoppingCartItemRepository.Delete(product);
    }

    public async Task ClearAllShioppingCartItems(ShoppingCartDto shoppingCartDto)
    {
        var shoppingCartItem = await _shoppingCartRepository.GetById(shoppingCartDto.ShoppingCartId);
        if (shoppingCartItem != null)
        {
            throw new Exception("List items from shopping cart are empty.");
        }
        var shoppingCart = _mapper.Map<ShoppingCart>(shoppingCartItem);
        await _shoppingCartItemRepository.ClearAllItems(shoppingCart);
    }
}
