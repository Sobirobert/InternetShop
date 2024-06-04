using Application.Dto.Cosmos;

namespace Application.Interfaces;

public interface ICosmosPostService
{
    Task<IEnumerable<CosmosProductDto>> GetAllPostAsync();

    Task<CosmosProductDto> GetPostByIdAsync(string id);

    Task<CosmosProductDto> AddNewPostAsync(CreateCosmosPostDto newPost);

    Task UpdatePostAsync(UpdateCosmosPostDto updatePost);

    Task DeletePostAsync(string id);
}