using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.CategoryDto;
public record UpdateCategoryDto(int Id, string CategoryName, string Description) : IMap
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCategoryDto, Category>();
    }
}