using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PictureRepository : IPictureRepository
{
    private readonly OnlineShopDBContext _context;

    public PictureRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Picture>> GetByProductId(int productId)
    {
        return await _context.Pictures.Include(x => x.Products).Where(x => x.Products.Select(x => x.Id).Contains(productId)).ToListAsync();
    }

    public async Task<Picture> GetById(int id)
    {
        return await _context.Pictures.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Picture> Add(Picture picture)
    {
        var createdPicture = await _context.Pictures.AddAsync(picture);
        await _context.SaveChangesAsync();
        return createdPicture.Entity;
    }

    public async Task Delete(Picture picture)
    {
        _context.Pictures.Remove(picture);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task SetMainPicture(int productId, int id)
    {
        var currentMainPicture =
            await _context.Pictures
        .Where(p => p.Products.Any(pr => pr.Id == productId))
        .ExecuteUpdateAsync(p => p.SetProperty(x => x.Main, false));

        var newMainPicture =
            await _context.Pictures
        .Where(p => p.Id == id)
        .ExecuteUpdateAsync(p => p.SetProperty(x => x.Main, true));

        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }
}