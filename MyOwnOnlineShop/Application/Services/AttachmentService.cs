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

    public async Task<IEnumerable<AttachmentDto>> GetAttachmentsByProductIdAsync(int productId)
    {
        var attachment = await _attachmentRepository.GetByProductIdAsync(productId);
        return _mapper.Map<IEnumerable<AttachmentDto>>(attachment);
    }

    public async Task<AttachmentDto> AddAttachmentToProductAsync(int productId, IFormFile file)
    {
        var product = await _productRepository.GetByIdAsync(productId);

        var attachment = new Attachment()
        {
            Products = new List<Product> { product },
            Name = file.FileName,
            Path = file.SaveFile()
        };

        var result = await _attachmentRepository.AddAsync(attachment);
        return _mapper.Map<AttachmentDto>(result);
    }

    public async Task DelateAttachmentAsync(int id)
    {
        var attachment = await _attachmentRepository.GetByIdAsync(id);
        await _attachmentRepository.DeleteAsync(attachment);
        File.Delete(attachment.Path);
    }

    public async Task<DownloadAttachmentDto> DownloadAttachmentByIdAsync(int id)
    {
        var attachment = await _attachmentRepository.GetByIdAsync(id);

        return new DownloadAttachmentDto()
        {
            Name = attachment.Name,
            Content = File.ReadAllBytes(attachment.Path)
        };
    }
}