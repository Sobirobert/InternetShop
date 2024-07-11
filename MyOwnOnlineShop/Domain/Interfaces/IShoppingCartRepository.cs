using Domain.Entities;

namespace Domain.Interfaces;

public interface IShoppingCartRepository
{
    Task<List<int>> GetAllShoppingCart();
    Task<IEnumerable<Product>> GetShoppingCartItems(int shoppingCartId);
    Task<ShoppingCartItem> GetShoppingCartById(int id);
    Task<double> GetShoppingCartTotal(int shoppingCartId);
    Task ClearCart(int shoppingCartId);
    Task AddToCart(Product product, int shoppingCartId);
    Task RemoveFromCart(Product product, int shoppingCartId);
}
