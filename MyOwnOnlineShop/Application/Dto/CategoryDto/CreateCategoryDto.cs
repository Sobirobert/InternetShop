using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.CategoryDto;
public record CreateCategoryDto(string CategoryName, string Description) : IMap
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCategoryDto, Category>();
    }
}