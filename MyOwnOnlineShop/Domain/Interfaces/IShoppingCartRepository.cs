using Domain.Entities;

namespace Domain.Interfaces;

public interface IShoppingCartRepository
{
    Task<List<int>> GetAllShoppingCart();
    Task<IEnumerable<Product>> GetShoppingCartItems(int id);
    Task<ShoppingCartItem> GetShoppingCartById(int id);
    Task<double> GetShoppingCartTotal(int id);
    Task ClearCart(int id);
    Task AddToCart(Product product, int id);
    Task RemoveFromCart(Product product, int id);
}
