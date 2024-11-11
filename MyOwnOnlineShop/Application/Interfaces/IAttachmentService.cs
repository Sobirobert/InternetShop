using Application.Dto.AttachmentDto;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces;
public interface IAttachmentService
{
    Task<IEnumerable<AttachmentDto>> GetAttachmentsByProductId(int productId);

    Task<DownloadAttachmentDto> DownloadAttachmentById(int id);

    Task<AttachmentDto> AddAttachmentToProduct(int productId, IFormFile filer);

    Task DelateAttachment(int id);
}