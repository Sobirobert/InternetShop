using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Dto.ProductDtoFolder;
public record CreateProductDto(
    string Title,
    string ShortDescription,
    string LongDescription,
    string Details,
    int YearOfProduction,
    int Amount,
    bool IsProductOfTheWeek,
    TypeProduct Type,
    int CategoryId
) 
    : IMap
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProductDto, Product>();
    }
}