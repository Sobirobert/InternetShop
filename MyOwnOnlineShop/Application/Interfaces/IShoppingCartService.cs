
using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IShoppingCartService
{
    Task<List<int>> GetAllShoppingCartIdAsync();
    Task<IEnumerable<ProductDto>> GetAllItemsFromShoppingCartById(int shoppingCartId);
    Task<double> GetTotalPriceOfShoppingCartAsync(int shoppingCartId);
    Task<ShoppingCartItemDto> AddNewProductToShippingCartAsync(Product product, int shoppingCartId);
    Task RemoveProductFromShoppingCartByIdAsync(Product product, int shoppingCartId);
    Task ClearShoppingCartAsync(int shoppingCartId);
}
