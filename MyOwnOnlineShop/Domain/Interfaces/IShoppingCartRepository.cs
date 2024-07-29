using Domain.Entities;

namespace Domain.Interfaces;

public interface IShoppingCartRepository
{
    Task<ShoppingCart> GetById(int cartId);

    Task<IEnumerable<Product>> GetAllProducts(int cartId);

    Task<IEnumerable<ShoppingCartItem>> GetAlltems(int cartId);

    Task<double> GetTotalPrice(int cartId);

    Task ClearCart(ShoppingCart shoppingCart);

    Task<ShoppingCart> CreateNew();

    Task<ShoppingCart> Add(int productId, ShoppingCart shoppingCart);

    Task Remove(int productId, ShoppingCart shoppingCart);
}