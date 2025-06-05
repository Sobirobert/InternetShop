using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto;

public record PictureDto( int Id, string Name, byte[] Image, bool Main) : IMap
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Picture, PictureDto>();
    }
}