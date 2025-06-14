using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class AttachmentRepository(OnlineShopDBContext context) : IAttachmentRepository<Attachment>
{
    public async Task<IEnumerable<Attachment>> GetByProductId(int productId)
    {
        return await context.Attachments.Include(x => x.Products).Where(x => x.Products.Select(x => x.Id).Contains(productId)).ToListAsync();
    }

    public async Task<Attachment> Get(int id)
    {
        return await context.Attachments.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task Add(Attachment entity)
    {
        var createdAttachment = await context.Attachments.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Attachment entity)
    {
        context.Attachments.Remove(entity);
        await context.SaveChangesAsync();
        await Task.CompletedTask;
    }
}