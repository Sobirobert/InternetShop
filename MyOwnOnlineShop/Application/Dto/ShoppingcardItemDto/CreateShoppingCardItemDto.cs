using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ShoppingcartItemDto;

public class CreateShoppingCardItemDto : IMap
{
    public int Amount { get; set; }
    public int ProductId { get; set; }
    public int ShoppingCardId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ShoppingCardItemDto, ShoppingCardItem>();
    }
}
