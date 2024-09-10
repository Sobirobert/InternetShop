using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.Order;

public class UpdateOrderItemDto : IMap
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }
    public DateTime ModifcateDate { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateOrderItemDto, OrderItem>()
        .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => src.ModifcateDate));
    }
}
