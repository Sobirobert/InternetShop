using Domain.Entities;

namespace Domain.Interfaces;

public interface IShoppingCartItemRepository
{
    Task<IEnumerable<ShoppingCartItem>> GetAllItems(int shoppingCartId);
    Task<IEnumerable<Product>> GetAllProducts(int shoppingCartId);
    Task<ShoppingCartItem> GetById(int id);
    Task<ShoppingCartItem> Add(int idProduct);
    Task Update(ShoppingCartItem shoppingCartItem);
    Task Delete(ShoppingCartItem shoppingCartItem);
    Task ClearAllItems(ShoppingCart shoppingCart);
}
