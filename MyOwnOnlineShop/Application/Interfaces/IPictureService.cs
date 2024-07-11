using Application.Dto;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces;

public interface IPictureService
{
    Task<PictureDto> AddPictureToProduct(int productId, IFormFile file);

    Task<IEnumerable<PictureDto>> GetPicturesByProductId(int productId);

    Task<PictureDto> GetPictureById(int id);

    Task SetMainPicture(int productId, int id);

    Task DeletePicture(int id);
}