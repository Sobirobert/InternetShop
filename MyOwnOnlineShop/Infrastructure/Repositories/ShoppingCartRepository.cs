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

    public async Task<List<int>> GetAllShoppingCart()
    {
        var shoppingCartIDs = await _context.ShoppingCartItems
            .Select(o => o.ShoppingCartId).ToListAsync();
        return shoppingCartIDs;
    }

    public async Task<IEnumerable<Product>> GetShoppingCartProducts(int cartId)
    {
        var productsId = await _context.ShoppingCartItems
            .Where(c => c.ShoppingCartId == cartId)
            .SelectMany(x => x.ProductsId).ToListAsync();

        var productList = new List<Product>();
            foreach (var product in productsId)
            {
            var productItem = await _context.Products.FirstOrDefaultAsync(x => x.Id == product);
            if (productItem!=null)
            {
                await productList.Add(productItem);
            }    
              
            }
        return productList;
    }

    public async Task<ShoppingCartItem> GetShoppingCartById(int id)
    {
        return await _context.ShoppingCartItems.SingleOrDefaultAsync(x => x.ShoppingCartId == id);
    }

    public async Task AddToCart(int productId, int cartId)
    {
        var shoppingCartItem = await _context.ShoppingCartItems
            .SingleOrDefaultAsync(s => s.ShoppingCartId == cartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = id,
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

    public async Task<double> GetShoppingCartTotal(int id)
    {
        var total = await _context.ShoppingCartItems.Where(c => c.ShoppingCartId == id)
                .Select(c => c.Product.Price * c.Amount).SumAsync();
        return total;
    }

    public async Task RemoveFromCart(int productId, int carId)
    {
        var shoppingCartItem =
                  await _context.ShoppingCartItems.SingleOrDefaultAsync(
                       s => s.ShoppingCartId == id && s.Product.Id == product.Id);

        var localAmount = 0;
        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
                Console.WriteLine($"Your ShoppingCart amount is = {localAmount}");
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
                Console.WriteLine($"Your ShoppingCart amount is = 0 ");
            }
        }
        else
        {
            Console.WriteLine("Empty Shopping cart");
        }

        await _context.SaveChangesAsync();
    }
    public async Task ClearCart(int shoppingCartId)
    {
        var cartItems = _context.ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == shoppingCartId);

        _context.ShoppingCartItems.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
    }
}
