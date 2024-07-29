using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ShoppingcartItemDto;

public class ShoppingCartDto : IMap
{
    public int ShoppingCartId { get; set; }
    public List<ShoppingCartItemsDto> ShoppingCartItems { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ShoppingCart, ShoppingCartDto>();
    }
}