using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ShoppingcartItemDto;

public class ShoppingCartItemDto : IMap
{
    public int ShoppingCartItemId { get; set; }
    public int Amount { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    // int ShoppingCartId { get; set; }
    public double Price { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ShoppingCartItem, ShoppingCartItemDto>();
    }
}