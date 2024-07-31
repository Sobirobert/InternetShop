using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly OnlineShopDBContext _context;

    public ShoppingCartRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task<ShoppingCart> GetById(int cartId)
    {
        return await _context.ShoppingCarts
           .SingleOrDefaultAsync(c => c.ShoppingCartId == cartId);
    }

    public async Task<ShoppingCart> CreateNew()
    {
        var shoppingCart = new ShoppingCart();
        //{
        //    ShoppingCartItems = new List<ShoppingCartItem>()
        //};
        await _context.AddAsync(shoppingCart);
        await _context.SaveChangesAsync();
        return shoppingCart;
    }

    public async Task<ShoppingCart> AddProduct(ShoppingCartItem shoppingCartItem, ShoppingCart shoppingCart)
    {
        {
            shoppingCart.LastModified = DateTime.Now;
            var shoppingCartProduct = shoppingCart.ShoppingCartItems.FirstOrDefault(x => x.ShoppingCartItemId == shoppingCartItem.ShoppingCartItemId);
            if (shoppingCartProduct != null)
            {
                
                shoppingCartProduct.Amount++;
            }
            else
            {
                shoppingCart.ShoppingCartItems.Add(shoppingCartProduct);
            }
            await _context.SaveChangesAsync();
            return shoppingCart;
        }
    }

    public async Task<IEnumerable<ShoppingCartItem>> GetAlltems(int cartId)
    {
        var shoppingCart = await _context.ShoppingCarts
                .SingleOrDefaultAsync(c => c.ShoppingCartId == cartId);
        return shoppingCart.ShoppingCartItems;
        
    }

    public async Task<double> GetTotalPrice(int cartId)
    {
        var shoppingCart = await _context.ShoppingCarts
            .SingleOrDefaultAsync(s => s.ShoppingCartId == cartId);
        var allItems = shoppingCart.ShoppingCartItems;
        double total = 0;
        foreach (var item in allItems)
        {
            total = +(item.Amount * item.Price);
        }
        return total;
    }

    public async Task RemoveProduct(ShoppingCartItem shoppingCartItem, ShoppingCart shoppingCart)
    {
        shoppingCart.LastModified = DateTime.Now;
        var shoppingCartProduct = shoppingCart.ShoppingCartItems.FirstOrDefault(x => x.ShoppingCartItemId == shoppingCartItem.ShoppingCartItemId);
        if (shoppingCartProduct != null)
        {
            if (shoppingCartProduct.Amount > 1)
            {
                shoppingCartProduct.Amount--;
            }
            else
            {
                shoppingCart.ShoppingCartItems.Remove(shoppingCartProduct);
                _context.ShoppingCartsItems.Remove(shoppingCartProduct);
            }
        }
        else
        {
            throw new Exception("There is not product in the list.");
        }
        await _context.SaveChangesAsync();
    }

    public async Task Delete(ShoppingCart shoppingCart)
    {
        _context.ShoppingCarts.Remove(shoppingCart);
        await _context.SaveChangesAsync();
    }
}