using Application.Dto.AttachmentDto;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces;

public interface IAttachmentService
{
    Task<IEnumerable<AttachmentDto>> GetAttachmentsByProductIdAsync(int productId);

    Task<DownloadAttachmentDto> DownloadAttachmentByIdAsync(int id);

    Task<AttachmentDto> AddAttachmentToProductAsync(int productId, IFormFile filer);

    Task DelateAttachmentAsync(int id);
}