using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.CategoryDto;

public class CategoryDto : IMap
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public int totalRecords { get; set; }
    public DateTime CreateDateTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.CreateDateTime, opt => opt.MapFrom(src => src.Created));
    }
}