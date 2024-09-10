using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Order;

public class UpdateOrderDto
{
    public int OrderId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public ShippingStatus ShippingStatus { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public double OrderTotal { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateOrderDto, Domain.Entities.Order>();
    }
}
