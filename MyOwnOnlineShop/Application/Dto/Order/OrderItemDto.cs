using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.Order;

public class OrderItemDto : IMap
{
    public int OrderItemId { get; set; }
    public string ItemName { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }
    public DateTime ModifcateDate{ get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderItem, OrderItemDto>()
             .ForMember(dest => dest.ModifcateDate, opt => opt.MapFrom(src => src.LastModified));
    }
}