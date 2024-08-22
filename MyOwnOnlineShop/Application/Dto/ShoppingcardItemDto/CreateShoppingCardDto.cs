using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ShoppingcardItemDto;

public class CreateShoppingCardDto : IMap
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateShoppingCardDto, ShoppingCard>();
    }
}
