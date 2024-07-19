
using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

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

    public async Task<IEnumerable<ProductDto>> GetAllItemsFromShoppingCartById(int shoppingCartId)
    {
        var allProducts = await _shoppingCartRepository.GetShoppingCartProducts(shoppingCartId);
        return _mapper.Map<IEnumerable<ProductDto>>(allProducts);
    }

    public async Task<double> GetTotalPriceOfShoppingCart(int shoppingCartId)
    {
        var totalPrice = await _shoppingCartRepository.GetShoppingCartTotal(shoppingCartId);
        return totalPrice;
    }

    public async Task ClearShoppingCart(int shoppingCartId)
    {
        await _shoppingCartRepository.ClearCart( shoppingCartId);
    }

    public async Task RemoveProductFromShoppingCartById(int productId, int shoppingCartId)
    {
        await _shoppingCartRepository.RemoveFromCart(productId, shoppingCartId);
    }

    public Task<ShoppingCartDto> AddNewProductToShippingCart(int productId, int shoppingCartId)
    {
        throw new NotImplementedException();
    }
}
