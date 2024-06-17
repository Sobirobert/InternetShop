using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AttachmentRepository : IAttachmentRepository
{
    private readonly OnlineShopDBContext _context;

    public AttachmentRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Attachment>> GetByProductIdAsync(int productId)
    {
        return await _context.Attachments.Include(x => x.Products).Where(x => x.Products.Select(x => x.Id).Contains(productId)).ToListAsync();
    }

    public async Task<Attachment> GetByIdAsync(int id)
    {
        return await _context.Attachments.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Attachment> AddAsync(Attachment attachment)
    {
        var createdAttachment = await _context.Attachments.AddAsync(attachment);
        await _context.SaveChangesAsync();
        return createdAttachment.Entity;
    }

    public async Task DeleteAsync(Attachment picture)
    {
        _context.Attachments.Remove(picture);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }
}