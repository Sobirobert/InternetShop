using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ShoppingcartItemDto;

public class ShoppingCardItemDto : IMap
{
    public int ShoppingCardItemId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
    public int ShoppingCardId { get; set; }
    public double Price { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ShoppingCardItem, ShoppingCardItemDto>();
    }
}