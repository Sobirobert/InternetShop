using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Dto.OrdersDto;
public record UpdateOrderDto(int OrderId, List<OrderItem> OrderItems, ShippingStatus ShippingStatus, PaymentStatus PaymentStatus) : IMap
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateOrderDto, Order>();
    }
}