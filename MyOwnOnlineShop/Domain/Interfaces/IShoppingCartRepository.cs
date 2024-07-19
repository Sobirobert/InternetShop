using Domain.Entities;

namespace Domain.Interfaces;

public interface IShoppingCartRepository
{
    Task<IEnumerable<ShoppingCart>> GetAllShoppingCart();
    Task<IEnumerable<Product>> GetShoppingCartProducts(int cartId);
    Task<ShoppingCart> GetShoppingCartById(int cartId);
    Task<double> GetShoppingCartTotal(int cartId);
    Task ClearCart(int cartId);
    Task AddToCart(int productId, int cartId);
    Task RemoveFromCart(int productId, int cartId);
}
