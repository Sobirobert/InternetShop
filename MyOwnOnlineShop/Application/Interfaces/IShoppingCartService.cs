
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
    Task<ShoppingCartDto> AddNewProductToShippingCartAsync(ProductDto product, int shoppingCartId);
    Task RemoveProductFromShoppingCartByIdAsync(ProductDto productDto, int shoppingCartId);
    Task ClearShoppingCartAsync(int shoppingCartId);
}
