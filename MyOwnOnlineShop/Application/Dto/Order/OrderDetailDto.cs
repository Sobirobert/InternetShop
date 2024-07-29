using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.Order;

public class OrderDetailDto : IMap
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }
    public Product Product { get; set; }
    public Domain.Entities.Order Order { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderDetail, OrderDetailDto>();
    }
}