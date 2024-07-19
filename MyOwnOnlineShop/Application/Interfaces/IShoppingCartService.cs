
using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IShoppingCartService
{
    Task<IEnumerable<ProductDto>> GetAllItemsFromShoppingCartById(int shoppingCartId);
    Task<double> GetTotalPriceOfShoppingCart(int shoppingCartId);
    Task<ShoppingCartDto> AddNewProductToShippingCart(int productId, int shoppingCartId);
    Task RemoveProductFromShoppingCartById(int productId, int shoppingCartId);
    Task ClearShoppingCart(int shoppingCartId);
}
