using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.ShoppingcartItemDto;

public class CreateShoppingCartItemDto : IMap
{
    public int Amount { get; set; }
    public int ShoppingCartId { get; set; }
    public double Price { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ShoppingCartItem, ShoppingCartItemDto>();
    }
}
