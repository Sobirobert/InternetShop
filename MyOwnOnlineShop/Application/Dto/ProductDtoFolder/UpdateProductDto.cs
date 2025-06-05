using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Dto.ProductDtoFolder;
public record UpdateProductDto(
    int Id, 
    string Title, 
    string ShortDescription, 
    string LongDescription, 
    string Details, 
    int YearOfProduction, 
    double Price, 
    int Amount,
    bool IsProductOfTheWeek, 
    TypeProduct Type) 
    : IMap
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateProductDto, Product>();
    }
}