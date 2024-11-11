using Application.Dto.AttachmentDto;
using Application.ExtensionMethods;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services;
public class AttachmentService : IAttachmentService
{
    private readonly IAttachmentRepository _attachmentRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public AttachmentService(IAttachmentRepository attachmentRepository, IProductRepository productRepository, IMapper mapper)
    {
        _attachmentRepository = attachmentRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AttachmentDto>> GetAttachmentsByProductId(int productId)
    {
        var attachment = await _attachmentRepository.GetByProductId(productId);
        return _mapper.Map<IEnumerable<AttachmentDto>>(attachment);
    }

    public async Task<AttachmentDto> AddAttachmentToProduct(int productId, IFormFile file)
    {
        var product = await _productRepository.GetById(productId);

        var attachment = new Attachment()
        {
            Products = new List<Product> { product },
            Name = file.FileName,
            Path = file.SaveFile()
        };

        var result = await _attachmentRepository.Add(attachment);
        return _mapper.Map<AttachmentDto>(result);
    }

    public async Task DelateAttachment(int id)
    {
        var attachment = await _attachmentRepository.GetById(id);
        await _attachmentRepository.Delete(attachment);
        File.Delete(attachment.Path);
    }

    public async Task<DownloadAttachmentDto> DownloadAttachmentById(int id)
    {
        var attachment = await _attachmentRepository.GetById(id);

        return new DownloadAttachmentDto()
        {
            Name = attachment.Name,
            Content = File.ReadAllBytes(attachment.Path)
        };
    }
}