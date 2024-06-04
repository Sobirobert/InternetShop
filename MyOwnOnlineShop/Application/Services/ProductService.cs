using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class ProductService : IProductService
{
    public Task<PostDto> AddNewPostAsync(CreateProductDto newPost, string userId)
    {
        throw new NotImplementedException();
    }

    public Task DeletePostAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PostDto>> GetAllPostsAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetAllPostsCountAsync(string filterBy)
    {
        throw new NotImplementedException();
    }

    public Task<PostDto> GetPostByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePostAsync(UpdateProductDto updatePost)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserOwnsPostAsync(int postId, string userId)
    {
        throw new NotImplementedException();
    }
}
