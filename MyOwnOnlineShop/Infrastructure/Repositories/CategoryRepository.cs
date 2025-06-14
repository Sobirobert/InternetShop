using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CategoryRepository(OnlineShopDBContext context) : ICategoryRepository
{
    public async Task<int> GetProductsCountInCategory(int id)
    {
        var cateory = await context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        var count = await context.Products.Where(x => x.CategoryId == cateory.Id).CountAsync();
        return count;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category> GetById(int id)
    {
        return await context.Categories
            .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category> GetByName(string name)
    {
        return await context.Categories
            .SingleOrDefaultAsync(c => c.CategoryName == name);
    }

    public async Task<Category> Add(Category category)
    {
        var createdCategory = await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        return createdCategory.Entity;
    }

    public async Task Update(Category category)
    {
        category.LastModified = DateTime.Now;
        context.Categories.Update(category);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Category category)
    {
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }
}