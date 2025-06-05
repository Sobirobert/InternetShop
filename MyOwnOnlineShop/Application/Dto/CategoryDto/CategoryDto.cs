using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.CategoryDto;
public record CategoryDto(int Id, string CategoryName, string Description, int TotalRecords, DateTime CreateDateTime) : IMap
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.CreateDateTime, opt => opt.MapFrom(src => src.Created));
    }
}