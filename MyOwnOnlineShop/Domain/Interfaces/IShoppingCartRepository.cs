using Domain.Entities;

namespace Domain.Interfaces;

public interface IShoppingCartRepository
{
    Task<List<int>> GetAllShoppingCart();
    Task<IEnumerable<Product>> GetShoppingCartProducts(int id);
    Task<ShoppingCartItem> GetShoppingCartById(int id);
    Task<double> GetShoppingCartTotal(int id);
    Task ClearCart(int id);
    Task AddToCart(int productId, int cartId);
    Task RemoveFromCart(int productId, int id);
}
