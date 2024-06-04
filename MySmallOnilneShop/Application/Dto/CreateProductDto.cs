
using Application.Dto.Enums;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto;

public class CreateProductDto : IMap
{
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int YearOfProduction { get; set; }
    public Enums.Type Type { get; set; }
    public Category Category { get; set; }
    public DateTime CreationDate { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProductDto, Product>()
             .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.CreationDate == DateTime.UtcNow));
    }
}
