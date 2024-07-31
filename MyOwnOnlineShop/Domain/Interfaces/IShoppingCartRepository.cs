using Domain.Entities;

namespace Domain.Interfaces;

public interface IShoppingCartRepository
{
    Task<ShoppingCart> GetById(int cartId);
    Task<IEnumerable<ShoppingCartItem>> GetAlltems(int cartId);
    Task<double> GetTotalPrice(int cartId);
    Task Delete(ShoppingCart shoppingCart);
    Task<ShoppingCart> CreateNew();
    Task<ShoppingCart> AddProduct(ShoppingCartItem shoppingCartItem, ShoppingCart shoppingCart);
    Task RemoveProduct(ShoppingCartItem shoppingCartItem, ShoppingCart shoppingCart);
}