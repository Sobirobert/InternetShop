using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly OnlineShopDBContext _context;
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public ShoppingCartRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task<List<int>> GetAllShoppingCartAsync()
    {
        var shoppingCartIDs = await _context.ShoppingCartItems
            .Select(o => o.ShoppingCartId).ToListAsync();
        return shoppingCartIDs;
    }

    public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsAsync(int shoppingCartId)
    {
        return await _context.ShoppingCartItems
            .Where(c => c.ShoppingCartId == shoppingCartId)
            .Include(s => s.Product).ToListAsync();
    }

    public async Task<ShoppingCartItem> GetShoppingCartByIdAsync(int id)
    {
        return await _context.ShoppingCartItems.SingleOrDefaultAsync(x => x.ShoppingCartId == id);
    }

    public async Task AddToCartAsync(Product product, int shoppingCartId)
    {
        var shoppingCartItem = await _context.ShoppingCartItems
            .SingleOrDefaultAsync(s => s.ShoppingCartId == shoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = shoppingCartId,
                Product = product,
                Amount = 1
            };

            await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
            await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<double> GetShoppingCartTotalAsync(int shoppingCartId)
    {
        var total = await _context.ShoppingCartItems.Where(c => c.ShoppingCartId ==  shoppingCartId)
                .Select(c => c.Product.Price * c.Amount).SumAsync();
        return total;
    }

    public async Task RemoveFromCartAsync(Product product, int shoppingCartId)
    {
        var shoppingCartItem =
                  await _context.ShoppingCartItems.SingleOrDefaultAsync(
                       s => s.Product.Id == product.Id && s.ShoppingCartId == shoppingCartId);

        var localAmount = 0;

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount >= 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
                Console.WriteLine($"Your ShoppingCart amount is = {localAmount}");
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }
        else 
        {
            Console.WriteLine("Empty Shopping cart");
        }

        await _context.SaveChangesAsync();
    }
    public async Task ClearCartAsync(int shoppingCartId)
    {
        var cartItems = _context.ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == shoppingCartId);

        _context.ShoppingCartItems.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
    }
}
