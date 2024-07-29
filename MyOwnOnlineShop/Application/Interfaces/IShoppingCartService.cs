using Application.Dto;
using Application.Dto.ShoppingcartItemDto;

namespace Application.Interfaces;

public interface IShoppingCartService
{
    Task<ShoppingCartDto> GetShoppingCartByID(int id);

    Task<IEnumerable<ShoppingCartItemsDto>> GetAllShoppingCartItems(int shoppingCartId);

    Task<IEnumerable<ProductDto>> GetAllItemsFromShoppingCartById(int shoppingCartId);

    Task<double> GetTotalPriceOfShoppingCart(int shoppingCartId);

    Task<ShoppingCartDto> CreateNewShoppingCart();

    Task<ShoppingCartDto> AddNewProductToShippingCart(int productId, int shoppingCart);

    Task RemoveProductFromShoppingCartById(int productId, int shoppingCart);

    Task ClearShoppingCart(int shoppingCart);
}