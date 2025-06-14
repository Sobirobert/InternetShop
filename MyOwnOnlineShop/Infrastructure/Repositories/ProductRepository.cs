using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ProductRepository(OnlineShopDBContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        return await context.Products
            .Where(m => m.Title.ToLower().Contains(filterBy.ToLower()) || m.ShortDescription.ToLower().Contains(filterBy.ToLower()))
            .OrderByPropertyName(sortField, ascending)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        var product = await context.Products
            .FirstOrDefaultAsync(x => x.Id == id);
        if (product == null)
        {
            throw new Exception("There are not product with this Id!");
        }
        return product;
    }

    public async Task<int> GetAllCount(string filterBy)
    {
        return await context.Products
            .Where(m => m.Title.ToLower()
            .Contains(filterBy.ToLower()) || m.ShortDescription.ToLower()
            .Contains(filterBy.ToLower()))
            .CountAsync();
    }

    public async Task<Product> Add(Product product)
    {
        product.Created = DateTime.Now;
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task Update(Product product)
    {
        product.LastModified = DateTime.Now;
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var product = await GetById(id);
        if (product == null)
        {
            throw new Exception("The Product with this id does not exist");
        }
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> ProductOfTheWeek()
    {
        return context.Products.Include(c => c.CategoryId).Where(p => p.IsProductOfTheWeek);
    }
}