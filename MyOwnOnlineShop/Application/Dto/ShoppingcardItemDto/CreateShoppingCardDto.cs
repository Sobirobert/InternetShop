using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ShoppingcardItemDto;

public class CreateShoppingCardDto
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateShoppingCardDto, ShoppingCard>();
    }
}
