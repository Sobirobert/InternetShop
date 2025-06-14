using Application.Dto;
using Application.ExtensionMethods;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Application.Services;
public class PictureService(IPictureRepository pictureRepository, IProductRepository productRepository, IMapper mapper) : IPictureService
{
    public async Task<PictureDto> AddPictureToProduct(int productId, IFormFile file)
    {
        var product = await productRepository.GetById(productId);
        var existingPictures = await pictureRepository.GetByProductId(productId);

        var picture = new Picture(0, file.FileName, file.GetBytes(), existingPictures.Count() == 0 ? true : false);

        var result = await pictureRepository.Add(picture);
        return mapper.Map<PictureDto>(result);
    }

    public async Task<IEnumerable<PictureDto>> GetPicturesByProductId(int productId)
    {
        var pictures = await pictureRepository.GetByProductId(productId);
        return mapper.Map<IEnumerable<PictureDto>>(pictures);
    }

    public async Task<PictureDto> GetPictureById(int id)
    {
        var picture = await pictureRepository.GetById(id);
        return mapper.Map<PictureDto>(picture);
    }

    public async Task DeletePicture(int id)
    {
        var picture = await pictureRepository.GetById(id);
        await pictureRepository.Delete(picture);
    }

    public async Task SetMainPicture(int productId, int id)
    {
        await pictureRepository.SetMainPicture(productId, id);
    }
}