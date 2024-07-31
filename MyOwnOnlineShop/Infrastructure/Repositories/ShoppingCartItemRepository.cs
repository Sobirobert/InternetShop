using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class ShoppingCartItemRepository : IShoppingCartItemRepository
{
    private readonly OnlineShopDBContext _context;

    public ShoppingCartItemRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ShoppingCartItem>> GetAllItems(int shoppingCartId)
    {
        return await _context.ShoppingCartsItems
            .Where(x => x.ShoppingCart.ShoppingCartId == shoppingCartId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProducts(int shoppingCartId)
    {
        var shoppingCart = await _context.ShoppingCarts
            .SingleOrDefaultAsync(c => c.ShoppingCartId == shoppingCartId);

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

    public async Task<ShoppingCartItem> GetById(int id)
    {
        return await _context.ShoppingCartsItems.FirstOrDefaultAsync(x => x.ShoppingCartItemId == id);
    }

    public async Task<ShoppingCartItem> Add(int idProduct)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == idProduct);
        var shoppingCartItems = new ShoppingCartItem
        {
            ShoppingCartItemId = product.Id,
            Amount = 1,
            //ShoppingCart = ,
            Price = product.Price,
        };
        return shoppingCartItems;
    }

    public async Task ClearAllItems(ShoppingCart shoppingCart)
    {
        var allItems = await _context.ShoppingCartsItems.ToListAsync();
        _context.ShoppingCartsItems.RemoveRange(allItems);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(ShoppingCartItem shoppingCartItem)
    {
        _context.ShoppingCartsItems.Remove(shoppingCartItem);
        await _context.SaveChangesAsync();
    }

    public async Task Update(ShoppingCartItem shoppingCartItem)
    {
        shoppingCartItem.LastModified = DateTime.Now;
        _context.ShoppingCartsItems.Update(shoppingCartItem);
        await _context.SaveChangesAsync();
    }
}
