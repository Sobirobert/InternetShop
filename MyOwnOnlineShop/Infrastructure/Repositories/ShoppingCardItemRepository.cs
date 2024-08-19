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

public class ShoppingCardItemRepository : IShoppingCardItemRepository
{
    private readonly OnlineShopDBContext _context;

    public ShoppingCardItemRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ShoppingCardItem>> GetAllItems(int shoppingCartId)
    {
        var shoppingCard = await _context.ShoppingCardItems
            .Where(x => x.ShoppingCardId == shoppingCartId)
            .ToListAsync();
        if (shoppingCard == null)
        {
            throw new Exception("Shopping Card Items aren't exist!");
        }
        return shoppingCard;
    }

    public async Task<IEnumerable<Product>> GetAllProducts(int shoppingCartId)
    {
        var shoppingCart = await _context.ShoppingCards
            .SingleOrDefaultAsync(c => c.ShoppingCardId == shoppingCartId);

        var products = shoppingCart.ShoppingCardItems;

        List<Product> productList = new List<Product>();
        foreach (var product in products)
        {
            for (int i = 0; i == product.Amount; i++)
            {
                var productItem = await _context.Products.SingleOrDefaultAsync(x => x.Id == product.ShoppingCardItemId);
                if (productItem != null)
                {
                    productList.Add(productItem);
                }
            }
        }
        return productList;
    }

    public async Task<ShoppingCardItem> GetById(int id)
    {
        var shoppingCard =  await _context.ShoppingCardItems.FirstOrDefaultAsync(x => x.ShoppingCardItemId == id);
        if (shoppingCard == null)
        {
            throw new Exception("Shopping Card Item isn't exist!");
        }
        return shoppingCard;
    }

    public async Task<ShoppingCardItem> Add(int idProduct, int shoppingCardId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == idProduct);
        if (product == null)
        {
            throw new Exception(" Product isn't exist!");
        }
        var shoppingCartItems = new ShoppingCardItem
        {
            ProductId = product.Id,
            Amount = 1,
            ShoppingCardId = shoppingCardId,
            Price = product.Price,
        };
        return shoppingCartItems;
    }

    public async Task ClearAllItems(int shoppingCard)
    {
        var allItems = await _context.ShoppingCardItems.Where(x => x.ShoppingCardId == shoppingCard).ToListAsync();
        if (allItems == null)
        {
            throw new Exception(" Items aren't exist!");
        }
        _context.ShoppingCardItems.RemoveRange(allItems);
        await _context.SaveChangesAsync();
    }

    public async Task Update(ShoppingCardItem shoppingCardItem)
    {
        if (shoppingCardItem == null)
        {
            throw new Exception(" Item isn't exist!");
        }
        _context.ShoppingCardItems.Update(shoppingCardItem);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int shoppingCardItemId)
    {
        var item = await _context.ShoppingCardItems.SingleOrDefaultAsync(x => x.ShoppingCardItemId == shoppingCardItemId);
        if (item == null)
        {
            throw new Exception(" Item isn't exist!");
        }
        _context.ShoppingCardItems.Remove(item);
        await _context.SaveChangesAsync();
    }
}
