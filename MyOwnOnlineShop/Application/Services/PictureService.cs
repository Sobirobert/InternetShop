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

    public async Task<PictureDto> AddPictureToProduct(int productId, IFormFile file)
    {
        var product = await _productRepository.GetById(productId);
        var existingPictures = await _pictureRepository.GetByProductId(productId);

        var picture = new Picture()
        {
            Products = new List<Product> { product },
            Name = file.FileName,
            Image = file.GetBytes(), 
            Main = existingPictures.Count() == 0 ? true : false
        };

        var result = await _pictureRepository.Add(picture);
        return _mapper.Map<PictureDto>(result);
    }

    public async Task<IEnumerable<PictureDto>> GetPicturesByProductId(int productId)
    {
        var pictures = await _pictureRepository.GetByProductId(productId);
        return _mapper.Map<IEnumerable<PictureDto>>(pictures);
    }

    public async Task<PictureDto> GetPictureById(int id)
    {
        var picture = await _pictureRepository.GetById(id);
        return _mapper.Map<PictureDto>(picture);
    }

    public async Task DeletePicture(int id)
    {
        var picture = await _pictureRepository.GetById(id);
        await _pictureRepository.Delete(picture);
    }

    public async Task SetMainPicture(int productId, int id)
    {
        await _pictureRepository.SetMainPicture(productId, id);
    }
}