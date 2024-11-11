using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly OnlineShopDBContext _context;

    public CategoryRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task<int> GetProductsCountInCategory(int id)
    {
        var cateory = await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        var count = await _context.Products.Where(x => x.CategoryId == cateory.Id).CountAsync();
        return count;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetById(int id)
    {
        return await _context.Categories
            .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category> GetByName(string name)
    {
        return await _context.Categories
            .SingleOrDefaultAsync(c => c.CategoryName == name);
    }

    public async Task<Category> Add(Category category)
    {
        var createdCategory = await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return createdCategory.Entity;
    }

    public async Task Update(Category category)
    {
        category.LastModified = DateTime.Now;
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}