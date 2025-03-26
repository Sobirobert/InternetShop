using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Dto.ProductDtoFolder;
public class ProductDto : IMap
{
    public int Id { get; set; }
    [DisplayProperty("Title of Product")]
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Details { get; set; }
    public int YearOfProduction { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }
    public bool IsProductOfTheWeek { get; set; }
    public TypeProduct Type { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreationDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.Created));
    }
}