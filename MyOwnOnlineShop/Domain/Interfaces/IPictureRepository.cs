using Domain.Entities;

namespace Domain.Interfaces;
public interface IPictureRepository
{
    Task<IEnumerable<Picture>> GetByProductId(int postId);

    Task<Picture> Add(Picture picture);

    Task<Picture> GetById(int id);

    Task SetMainPicture(int postId, int id);

    Task Delete(Picture picture);
}