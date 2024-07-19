using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly OnlineShopDBContext _context;
    private readonly IProductRepository _productRepository;

    public ShoppingCartRepository(OnlineShopDBContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCart()
    {
        return await _context.ShoppingCarts
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetShoppingCartProducts(int cartId)
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

    public async Task<ShoppingCart> GetShoppingCartById(int cartId)
    {
        return await _context.ShoppingCarts.SingleOrDefaultAsync(x => x.ShoppingCartId == cartId);
    }

    public async Task AddToCart(int productId, int cartId)
    {
        var shoppingCart = await _context.ShoppingCarts
            .SingleOrDefaultAsync(s => s.ShoppingCartId == cartId);
        var productPrice = await _context.Products.SingleOrDefaultAsync(x => x.Id == productId);

        if (shoppingCart == null)
        {
            List<ShoppingCartItem> newList = new List<ShoppingCartItem>();
            var newShoppingCart = new ShoppingCart
            {
                ShoppingCartId = cartId,
                ShoppingCartItems = newList
            };
            var newItem = new ShoppingCartItem
            {
                ShoppingCartId = cartId,
                ShoppingCartItemId = productId,
                Amount = 1,
                Price = productPrice.Price
            };
            await _context.ShoppingCartsItems.AddAsync(newItem);
        }
        else
        {
            var shoppingCartItem = _context.ShoppingCartsItems.FirstOrDefault(x => x.ShoppingCartItemId == productId);
            if (shoppingCartItem == null)
            {
                var Item = new ShoppingCartItem
                {
                    ShoppingCartId = cartId,
                    ShoppingCartItemId = productId,
                    Amount = 1,
                    Price = productPrice.Price
                };
                shoppingCart.ShoppingCartItems.Add(Item);
            }
            else
            {
                shoppingCartItem.Amount++;
                shoppingCartItem.Price = productPrice.Price * shoppingCartItem.Amount;
            }
        }
        await _context.SaveChangesAsync();
    }

    public async Task<double> GetShoppingCartTotal(int cartId)
    {
        var shoppingCart = await _context.ShoppingCarts
            .SingleOrDefaultAsync(s => s.ShoppingCartId == cartId);
        var allItems = shoppingCart.ShoppingCartItems;
        double total = 0;
        foreach (var item in allItems)
        {
            total = +item.Amount;
        }
        return total;
    }

    public async Task RemoveFromCart(int productId, int carId)
    {
        var shoppingCart = await _context.ShoppingCarts.SingleOrDefaultAsync(
                       s => s.ShoppingCartId == carId);
        if (shoppingCart == null)
        {
            throw new Exception("Shopping Cart doesn't exist!");
        }
        var product = await _context.ShoppingCartsItems.SingleOrDefaultAsync(s => s.ShoppingCartItemId == productId && s.ShoppingCartId == carId);
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
                _context.ShoppingCartsItems.Remove( product );
                throw new Exception("There is no such product in the shopping cart");
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
        var cartItems = _context.ShoppingCarts
                .Where(cart => cart.ShoppingCartId == shoppingCartId);
        _context.ShoppingCarts.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
    }
}
