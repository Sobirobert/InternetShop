using Domain.Entities;

namespace Domain.Interfaces;

public interface IShoppingCartRepository
{
    Task<List<int>> GetAllShoppingCartAsync();
    Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsAsync(int shoppingCartId);
    Task<ShoppingCartItem> GetShoppingCartByIdAsync(int id);
    Task<double> GetShoppingCartTotalAsync(int shoppingCartId);
    Task ClearCartAsync(int shoppingCartId);
    Task AddToCartAsync(Product product, int shoppingCartId);
    Task RemoveFromCartAsync(Product product, int shoppingCartId);
}
