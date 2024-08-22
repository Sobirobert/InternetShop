using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ShoppingcardItemDto;

public class UpdateShoppingCardItemDto : IMap
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateShoppingCardItemDto, ShoppingCardItem>();
    }
}
