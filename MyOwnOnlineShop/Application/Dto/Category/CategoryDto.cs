using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Category;

public class CategoryDto : IMap
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public List<Product> Products { get; set; }
    public int CategoryShowAll { get; set; }
    public DateTime CreateDateTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Category, CategoryDto>()
            .ForMember(dest => dest.CreateDateTime, opt => opt.MapFrom(src => src.CreateDateTime));
    }
}