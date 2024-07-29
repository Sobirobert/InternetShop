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

    public async Task<IEnumerable<Product>> GetAllProducts(int cartId)
    {
        var shoppingCart = await _context.ShoppingCarts
            .SingleOrDefaultAsync(c => c.ShoppingCartId == cartId);

        var products = shoppingCart.ShoppingCartItems;

        List<Product> productList = new List<Product>();
        foreach (var product in products)
        {
            for (int i = 0; i == product.Amount; i++)
            {
                var productItem = await _context.Products.SingleOrDefaultAsync(x => x.Id == product.ShoppingCartItemId);
                if (productItem != null)
                {
                    productList.Add(productItem);
                }
            }
        }
        return productList;
    }

    public async Task<IEnumerable<ShoppingCartItem>> GetAlltems(int cartId)
    {
        var shoppingCart = await _context.ShoppingCarts
          .SingleOrDefaultAsync(c => c.ShoppingCartId == cartId);
        return shoppingCart.ShoppingCartItems;
    }

    public async Task<ShoppingCart> CreateNew()
    {
        var shoppingCart = new ShoppingCart
        {
            ShoppingCartItems = new List<ShoppingCartItem>()
        };
        await _context.AddAsync(shoppingCart);
        await _context.SaveChangesAsync();
        return shoppingCart;
    }

    public async Task<ShoppingCart> Add(int productId, ShoppingCart shoppingCart)
    {
        var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == productId);
        if (product == null)
        {
            throw new Exception("Product isn't exist!");
        }

        var shoppingCartItem = await _context.ShoppingCartsItems.SingleOrDefaultAsync(x => x.ShoppingCartItemId == productId);
        if (shoppingCartItem != null)
        {
            var shoppingCartItemAdded = shoppingCart.ShoppingCartItems.FirstOrDefault(x => x.ShoppingCartItemId == shoppingCartItem.ShoppingCartItemId);
            if (shoppingCartItemAdded != null)
            {
                shoppingCartItemAdded.Amount++;
                shoppingCartItemAdded.Price = product.Price * shoppingCartItemAdded.Amount;
                await _context.SaveChangesAsync();
            }
            else
            {
                shoppingCartItem.Price = product.Price;
                shoppingCart.ShoppingCartItems.Add(shoppingCartItem);
                await _context.SaveChangesAsync();
            }
        }
        else
        {
            var Item = new ShoppingCartItem
            {
                ShoppingCartItemId = product.Id,
                Amount = 1,
                Price = product.Price,
                Created = DateTime.UtcNow
            };
            shoppingCart.ShoppingCartItems.Add(Item);
            await _context.SaveChangesAsync();
        }
        return shoppingCart;
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

    public async Task Remove(int productId, ShoppingCart shoppingCart)
    {
        shoppingCart.LastModified = DateTime.Now;
        if (shoppingCart == null)
        {
            throw new Exception("Shopping Cart doesn't exist!");
        }
        var product = await _context.ShoppingCartsItems.SingleOrDefaultAsync(s => s.ShoppingCartItemId == productId);
        var localAmount = 0;
        if (product != null)
        {
            if (product.Amount > 1)
            {
                product.Amount--;
                localAmount = product.Amount;
                Console.WriteLine($"Your ShoppingCart amount is = {localAmount}");
            }
            else
            {
                _context.ShoppingCartsItems.Remove(product);
                throw new Exception("There is no such product in the shopping cart");
            }
        }
        else
        {
            Console.WriteLine("Empty Shopping cart");
        }
        await _context.SaveChangesAsync();
    }

    public async Task ClearCart(ShoppingCart shoppingCart)
    {
        _context.ShoppingCarts.RemoveRange(shoppingCart);
        await _context.SaveChangesAsync();
    }
}