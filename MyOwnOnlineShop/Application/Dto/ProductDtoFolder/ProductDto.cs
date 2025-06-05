using Application.Dto.AttachmentsDto;
using Application.Dto.OrdersDto;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Dto.ProductDtoFolder;
public record ProductDto(
    int Id,
    string Title,
    string ShortDescription,
    string LongDescription,
    int Amount, string Details,
    int YearOfProduction,
    double Price,
    bool IsProductOfTheWeek,
    TypeProduct Type,
    Category Category,
    int CategoryId,
    ICollection<OrderDto> OrderItems,
    ICollection<PictureDto> Pictures,
    ICollection<AttachmentDto> Attachments,
    DateTime CreationDate
) 
    : IMap
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.Created));
    }
}