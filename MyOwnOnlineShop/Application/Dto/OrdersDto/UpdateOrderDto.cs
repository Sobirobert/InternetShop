﻿using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Dto.OrdersDto;
public class UpdateOrderDto : IMap
{
    public int OrderId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public ShippingStatus ShippingStatus { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateOrderDto, Order>();
    }
}