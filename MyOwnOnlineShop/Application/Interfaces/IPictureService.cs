using Application.Dto;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces;

public interface IPictureService
{
    Task<PictureDto> AddPictureToProductAsync(int postId, IFormFile file);

    Task<IEnumerable<PictureDto>> GetPicturesByProductIdAsync(int postId);

    Task<PictureDto> GetPictureByIdAsync(int id);

    Task SetMainPicture(int postId, int id);

    Task DeletePictureAsync(int id);
}