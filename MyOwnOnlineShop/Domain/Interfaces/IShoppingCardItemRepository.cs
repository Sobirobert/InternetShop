using Domain.Entities;

namespace Domain.Interfaces;

public interface IShoppingCardItemRepository
{
    Task<IEnumerable<ShoppingCardItem>> GetAllItems(int shoppingCardId);
    Task<IEnumerable<Product>> GetAllProducts(int shoppingCardId);
    Task<ShoppingCardItem> GetById(int id);
    Task<ShoppingCardItem> Add(int idProduct, int shoppingCardId);
    Task Update(ShoppingCardItem shoppingCardItem);
    Task Delete(int shoppingCardItemId);
    Task ClearAllItems(int shoppingCardId);
}
