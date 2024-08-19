using Application.Dto;
using Application.Dto.ShoppingcardItemDto;
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

public class ShoppingCartItemService : IShoppingCardItemService
{
    private readonly IShoppingCardItemRepository _shoppingCartItemRepository;
    private readonly IShoppingCardRepository _shoppingCartRepository;
    private readonly IMapper _mapper;

    public ShoppingCartItemService(IShoppingCardRepository shoppingCartRepository, IShoppingCardItemRepository shoppingCartItemRepository, IMapper mapper)
    {
        _mapper = mapper;
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _shoppingCartRepository = shoppingCartRepository;
    }

    public async Task<ShoppingCardItemDto> GetShoppingCardItemById(int id)
    {
        var item = await _shoppingCartItemRepository.GetById(id);
        return _mapper.Map<ShoppingCardItemDto>(item);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProducts(int shoppingCartId)
    {
        var shoppingCartItems = await _shoppingCartItemRepository.GetAllProducts(shoppingCartId);
        var result = _mapper.Map<IEnumerable<ProductDto>>(shoppingCartItems);
        return result;
    }

    public async Task<IEnumerable<ShoppingCardItemDto>> GetAllShoppingCardItems(int shoppingCartId)
    {
        var shoppingCartItem = await _shoppingCartRepository.GetAlltems(shoppingCartId);
        if (shoppingCartItem != null)
        {
            throw new Exception("List items from shopping cart are empty.");
        }
        return _mapper.Map<IEnumerable<ShoppingCardItemDto>>(shoppingCartItem);
    }

    public async Task<CreateShoppingCardItemDto> AddNewShoppingCardItem(int idProduct, int shoppingCardId)
    {
        var newProduct = await _shoppingCartItemRepository.Add(idProduct, shoppingCardId);
        return _mapper.Map<CreateShoppingCardItemDto>(newProduct);
    }

    public async Task UpdateShoppingCardItem(UpdateShoppingCardItemDto shoppingCartItem)
    {
        var existingProduct = await _shoppingCartItemRepository.GetById(shoppingCartItem.ShoppingCardItemId);
        var product = _mapper.Map(shoppingCartItem, existingProduct);
        await _shoppingCartItemRepository.Update(product);
    }

    public async Task DeleteShioppingCardItem(int shoppingCartItemId)
    {
        await _shoppingCartItemRepository.Delete(shoppingCartItemId);
    }

    public async Task ClearAllShioppingCardItems(int shoppingCardId)
    {
        await _shoppingCartItemRepository.ClearAllItems(shoppingCardId);
    }
}
