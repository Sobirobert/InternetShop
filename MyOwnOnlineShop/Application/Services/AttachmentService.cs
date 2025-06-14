using Application.Dto.AttachmentsDto;
using Application.ExtensionMethods;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services;
public class AttachmentService(IAttachmentRepository<Attachment> attachmentRepository, IProductRepository productRepository, IMapper mapper) : IAttachmentService
{
    public async Task<IEnumerable<AttachmentDto>> GetAttachmentsByProductId(int productId)
    {
        var attachment = await attachmentRepository.GetByProductId(productId);
        return mapper.Map<IEnumerable<AttachmentDto>>(attachment);
    }

    public async Task<AttachmentDto> AddAttachmentToProduct(int productId, IFormFile file)
    {
        var product = await productRepository.GetById(productId);
        var attachment = new Attachment(0, file.FileName, file.SaveFile());
        await attachmentRepository.Add(attachment);
        return mapper.Map<AttachmentDto>(attachment);
    }

    public async Task DelateAttachment(int id)
    {
        var attachment = await attachmentRepository.Get(id);
        await attachmentRepository.Delete(attachment);
        File.Delete(attachment.Path);
    }

    public async Task<DownloadAttachmentDto> DownloadAttachmentById(int id)
    {
        var attachment = await attachmentRepository.Get(id);
        return new DownloadAttachmentDto(attachment.Name, File.ReadAllBytes(attachment.Path));
    }
}