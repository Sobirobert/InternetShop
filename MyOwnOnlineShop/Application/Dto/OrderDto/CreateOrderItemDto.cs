using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.OrderDto;
public class CreateOrderItemDto : IMap
{
    public string ItemName { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }
    public DateTime CreatedDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrderItemDto, OrderItem>()
        .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.CreatedDate));
    }
}