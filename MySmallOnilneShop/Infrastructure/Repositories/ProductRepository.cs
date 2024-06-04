using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductRepository : IProductRepository
{
    private readonly OnlineShopContext _context;

    public ProductRepository(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(/*int pageNumber, int pageSize, string sortField, bool ascending, string filterBy*/)
    {

        //return await _context.Products
        //    .Where(m => m.Title.ToLower().Contains(filterBy.ToLower()) || m.Content.ToLower().Contains(filterBy.ToLower()))
        //    .OrderByPropertyName(sortField, ascending)
        //    .Skip((pageNumber - 1) * pageSize).Take(pageSize)
        //    .ToListAsync();
    }

    public async Task<int> GetAllCountAsync(string filterBy)
    {
        return await _context.Posts.Where(m => m.Title.ToLower().Contains(filterBy.ToLower()) || m.Content.ToLower().Contains(filterBy.ToLower())).CountAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Posts.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product> AddAsync(Product post)
    {
        //post.Created = DateTime.UtcNow;
        var createdPost = await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return createdPost.Entity;
    }

    public async Task UpdateAsync(Product post)
    {
        //post.LastModified = DateTime.UtcNow;
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Product post)
    {
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }
}
