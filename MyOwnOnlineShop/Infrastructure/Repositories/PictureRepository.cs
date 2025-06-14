using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PictureRepository(OnlineShopDBContext context) : IPictureRepository
{
    public async Task<IEnumerable<Picture>> GetByProductId(int productId)
    {
        return await context.Pictures.Include(x => x.Products).Where(x => x.Products.Select(x => x.Id).Contains(productId)).ToListAsync();
    }

    public async Task<Picture> GetById(int id)
    {
        return await context.Pictures.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Picture> Add(Picture picture)
    {
        var createdPicture = await context.Pictures.AddAsync(picture);
        await context.SaveChangesAsync();
        return createdPicture.Entity;
    }

    public async Task Delete(Picture picture)
    {
        context.Pictures.Remove(picture);
        await context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task SetMainPicture(int productId, int id)
    {
        var currentMainPicture =
            await context.Pictures
        .Where(p => p.Products.Any(pr => pr.Id == productId))
        .ExecuteUpdateAsync(p => p.SetProperty(x => x.Main, false));

        var newMainPicture =
            await context.Pictures
        .Where(p => p.Id == id)
        .ExecuteUpdateAsync(p => p.SetProperty(x => x.Main, true));

        await context.SaveChangesAsync();
        await Task.CompletedTask;
    }
}