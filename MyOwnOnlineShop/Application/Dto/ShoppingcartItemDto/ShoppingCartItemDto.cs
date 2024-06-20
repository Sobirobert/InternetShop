

using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ShoppingcartItemDto;

public class ShoppingCartItemDto : IMap
{
    public int ShoppingCartId { get; set; }
    public int ShoppingCartItemId { get; set; }
    public Product Product { get; set; }
    public int Amount { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ShoppingCartItem, ShoppingCartItemDto>();
    }
}
