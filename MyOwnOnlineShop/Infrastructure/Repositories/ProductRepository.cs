using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly OnlineShopDBContext _context;

    public ProductRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        return await _context.Products
            .Where(m => m.Title.ToLower().Contains(filterBy.ToLower()) || m.ShortDescription.ToLower().Contains(filterBy.ToLower()))
            .OrderByPropertyName(sortField, ascending)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.Products
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> GetAllCount(string filterBy)
    {
        return await _context.Products
            .Where(m => m.Title.ToLower()
            .Contains(filterBy.ToLower()) || m.ShortDescription.ToLower()
            .Contains(filterBy.ToLower()))
            .CountAsync();
    }

    public async Task<Product> Add(Product product)
    {
        product.Created = DateTime.Now;
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task Update(Product product)
    {
        product.LastModified = DateTime.Now;
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> ProductOfTheWeek()
    {
        return _context.Products.Include(c => c.CategoryId).Where(p => p.IsProductOfTheWeek);
    }
}