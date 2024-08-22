using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ShoppingCardRepository : IShoppingCardRepository
{
    private readonly OnlineShopDBContext _context;

    public ShoppingCardRepository(OnlineShopDBContext context)
    {
        _context = context;
    }
    public async Task<ShoppingCard> GetById(int cardId)
    {
        var shoppingCard = await _context.ShoppingCards
           .SingleOrDefaultAsync(c => c.ShoppingCardId == cardId);
        if (shoppingCard == null)
        {
            throw new Exception("Shopping Card isn't exist!");
        }
        return shoppingCard;
    }

    public async Task<IEnumerable<ShoppingCardItem>> GetAlltems(int cardId)
    {
        var shoppingCard = await _context.ShoppingCards
                .SingleOrDefaultAsync(c => c.ShoppingCardId == cardId);
        if (shoppingCard == null)
        {
            throw new Exception("Shopping Card isn't exist!");
        }
        return shoppingCard.ShoppingCardItems;
    }

    public async Task<double> GetTotalPrice(int cartId)
    {
        var shoppingCard = await _context.ShoppingCards
            .SingleOrDefaultAsync(s => s.ShoppingCardId == cartId);
        if (shoppingCard == null)
        {
            throw new Exception("Shopping Card is exist!");
        }
        var allItems = shoppingCard.ShoppingCardItems;
        double total = 0;
        foreach (var item in allItems)
        {
            total = +(item.Amount * item.Price);
        }
        return total;
    }

    public async Task<ShoppingCard> Add(ShoppingCard shoppingCard)
    {
        if (shoppingCard == null)
        {
            throw new Exception("Shopping Card is null!");
        }
        await _context.ShoppingCards.AddAsync(shoppingCard);
        await _context.SaveChangesAsync();
        return shoppingCard;
    }

    public async Task<ShoppingCard> Update(ShoppingCard shoppingCard)
    {
        if(shoppingCard == null)
        {
            throw new Exception("Shopping Card is null!");
        }
        _context.ShoppingCards.Update(shoppingCard);
        await _context.SaveChangesAsync();
        return shoppingCard;
    }

    public async Task Delete(int shoppingCardId)
    {
        var shoppingCard = await _context.ShoppingCards
           .SingleOrDefaultAsync(c => c.ShoppingCardId == shoppingCardId);
        if (shoppingCard == null)
        {
            throw new Exception("Shopping Card isn't exist!");
        }
        _context.ShoppingCards.Remove(shoppingCard);
        await _context.SaveChangesAsync();
    }
}