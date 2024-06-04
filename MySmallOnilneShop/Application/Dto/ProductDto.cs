using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
namespace Application.Dto;

public class ProductDto : IMap
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int YearOfProduction { get; set; }
    public Enums.Type Type { get; set; }
    public Category Category { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>();
    }
}
