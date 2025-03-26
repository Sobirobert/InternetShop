﻿using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Dto.OrdersDto;
public class OrderDto : IMap
{
    public int OrderId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public ShippingStatus ShippingStatus { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public double OrderTotal { get; set; }
    public DateTime OrderPlaced { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Order, OrderDto>()
            .ForMember(dest => dest.OrderPlaced, opt => opt.MapFrom(src => src.OrderPlaced));
    }
}