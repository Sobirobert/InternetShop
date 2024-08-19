using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ShoppingcartItemDto;

public class ShoppingCardDto : IMap
{
    public int ShoppingCardId { get; set; }
    public List<ShoppingCardItem> ShoppingCardItems { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ShoppingCard, ShoppingCardDto>();
    }
}