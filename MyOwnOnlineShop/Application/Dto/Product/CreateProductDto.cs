using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto;

public class CreateProductDto : IMap
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Details { get; set; }
    public int YearOfProduction { get; set; }
    public double Price { get; set; }
    public bool IsProductOfTheWeek { get; set; }
    public Domain.Enums.Type Type { get; set; }
    public int CategoryId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProductDto, Product>();
    }
}