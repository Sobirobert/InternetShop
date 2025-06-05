using Application.Dto.AttachmentsDto;
using Microsoft.AspNetCore.Http;
using static Application.Dto.AttachmentsDto.AttachmentDto;

namespace Application.Interfaces;
public interface IAttachmentService
{
    Task<IEnumerable<AttachmentDto>> GetAttachmentsByProductId(int productId);

    Task<DownloadAttachmentDto> DownloadAttachmentById(int id);

    Task<AttachmentDto> AddAttachmentToProduct(int productId, IFormFile filer);

    Task DelateAttachment(int id);
}