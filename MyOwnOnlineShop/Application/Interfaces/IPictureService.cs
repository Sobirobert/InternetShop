using Application.Dto;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces;

public interface IPictureService
{
    Task<PictureDto> AddPictureToProductAsync(int productId, IFormFile file);

    Task<IEnumerable<PictureDto>> GetPicturesByProductIdAsync(int productId);

    Task<PictureDto> GetPictureByIdAsync(int id);

    Task SetMainPicture(int productId, int id);

    Task DeletePictureAsync(int id);
}