
using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto;

public class UpdateProductDto : IMap
{
    public int Id {  get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public DateTime LastModified { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateProductDto, Product>()
            .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => src.LastModified == DateTime.UtcNow));
    }
}
