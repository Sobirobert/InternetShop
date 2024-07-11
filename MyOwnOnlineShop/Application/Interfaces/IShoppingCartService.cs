
using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IShoppingCartService
{
    Task<List<int>> GetAllShoppingCartId();
    Task<IEnumerable<ProductDto>> GetAllItemsFromShoppingCartById(int shoppingCartId);
    Task<double> GetTotalPriceOfShoppingCart(int shoppingCartId);
    Task<ShoppingCartDto> AddNewProductToShippingCart(ProductDto product, int shoppingCartId);
    Task RemoveProductFromShoppingCartById(ProductDto productDto, int shoppingCartId);
    Task ClearShoppingCart(int shoppingCartId);
}
