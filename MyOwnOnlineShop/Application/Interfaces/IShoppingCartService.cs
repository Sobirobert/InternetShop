using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
using Domain.Entities;

namespace Application.Interfaces;

public interface IShoppingCartService
{
    Task<ShoppingCartDto> GetShoppingCartById(int cartId);
    Task<IEnumerable<ShoppingCartItemDto>> GetAllShoppingCartItems(int cartId);
    Task<double> GetTotalPriceFromShoppingCart(int cartId);
    Task DeleteShoppingCart(ShoppingCartDto shoppingCart);
    Task<ShoppingCartDto> CreateNewShoppingCart();
    Task<ShoppingCartDto> AddProductToShoppingCart(ShoppingCartItemDto shoppingCartItem, ShoppingCartDto shoppingCart);
    Task RemoveProductFromShoppingCart(ShoppingCartItemDto shoppingCartItem, ShoppingCartDto shoppingCart);
}