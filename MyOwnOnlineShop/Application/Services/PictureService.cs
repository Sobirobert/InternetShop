using Application.Dto;
using Application.ExtensionMethods;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Application.Services;

public class PictureService : IPictureService
{
    private readonly IPictureRepository _pictureRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public PictureService(IPictureRepository pictureRepository, IProductRepository productRepository, IMapper mapper)
    {
        _pictureRepository = pictureRepository;
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<PictureDto> AddPictureToPostAsync(int productId, IFormFile file)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        var existingPictures = await _pictureRepository.GetByPostIdAsync(productId);

        var picture = new Picture()
        {
            Products = new List<Product> { product },
            Name = file.FileName,
            Image = file.GetBytes(), 
            Main = existingPictures.Count() == 0 ? true : false
        };

        var result = await _pictureRepository.AddAsync(picture);
        return _mapper.Map<PictureDto>(result);
    }

    public async Task<IEnumerable<PictureDto>> GetPicturesByPostIdAsync(int productId)
    {
        var pictures = await _pictureRepository.GetByPostIdAsync(productId);
        return _mapper.Map<IEnumerable<PictureDto>>(pictures);
    }

    public async Task<PictureDto> GetPictureByIdAsync(int id)
    {
        var picture = await _pictureRepository.GetByIdAsync(id);
        return _mapper.Map<PictureDto>(picture);
    }

    public async Task DeletePictureAsync(int id)
    {
        var picture = await _pictureRepository.GetByIdAsync(id);
        await _pictureRepository.DeleteAsync(picture);
    }

    public async Task SetMainPicture(int productId, int id)
    {
        await _pictureRepository.SetMainPictureAsync(productId, id);
    }
}