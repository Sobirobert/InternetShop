using Domain.Entities;

namespace Domain.Interfaces;

public interface IShoppingCardRepository
{
    Task<ShoppingCard> GetById(int cardId);
    Task<IEnumerable<ShoppingCardItem>> GetAlltems(int cardId);
    Task<double> GetTotalPrice(int cardId);
    Task<ShoppingCard> Add(ShoppingCard shoppingCard);
    Task<ShoppingCard> Update(ShoppingCard shoppingCard);
    Task Delete(int shoppingCardId);
}