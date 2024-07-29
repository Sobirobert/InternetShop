using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using static StackExchange.Redis.Role;

namespace Application.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IMapper _mapper;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
    {
        _mapper = mapper;
        _shoppingCartRepository = shoppingCartRepository;
    }

    public async Task<ShoppingCartDto> GetShoppingCartByID(int idCart)
    {
        var shoppingCart = await _shoppingCartRepository.GetById(idCart);
        return _mapper.Map<ShoppingCartDto>(shoppingCart);
    }

    public async Task<IEnumerable<ShoppingCartItemsDto>> GetAllShoppingCartItems(int shoppingCartId)
    {
        var shoppingCartItems = await _shoppingCartRepository.GetAlltems(shoppingCartId);
        return _mapper.Map<IEnumerable<ShoppingCartItemsDto>>(shoppingCartItems);
    }

    public async Task<IEnumerable<ProductDto>> GetAllItemsFromShoppingCartById(int shoppingCartId)
    {
        var shoppingItmes = await _shoppingCartRepository.GetAllProducts(shoppingCartId);
        return _mapper.Map<IEnumerable<ProductDto>>(shoppingItmes);
    }

    public async Task<double> GetTotalPriceOfShoppingCart(int shoppingCartId)
    {
        var totalPrice = await _shoppingCartRepository.GetTotalPrice(shoppingCartId);
        return totalPrice;
    }

    public async Task<ShoppingCartDto> CreateNewShoppingCart()
    {
        var shoppingCart = await _shoppingCartRepository.CreateNew();
        return _mapper.Map<ShoppingCartDto>(shoppingCart);
    }

    public async Task<ShoppingCartDto> AddNewProductToShippingCart(int productId, int shoppingCartId)
    {
        var existShoppingCart = await _shoppingCartRepository.GetById(shoppingCartId);
        var shoppingCart = await _shoppingCartRepository.Add(productId, existShoppingCart);
        return _mapper.Map<ShoppingCartDto>(shoppingCart);
    }

    public async Task RemoveProductFromShoppingCartById(int productId, int shoppingCartId)
    {
        var shoppingCart = await _shoppingCartRepository.GetById(shoppingCartId);
        await _shoppingCartRepository.Remove(productId, shoppingCart);
    }

    public async Task ClearShoppingCart(int shoppingCartId)
    {
        var shoppingCart = await _shoppingCartRepository.GetById(shoppingCartId);
        await _shoppingCartRepository.ClearCart(shoppingCart);
    }
}