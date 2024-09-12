using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.OrderDto;

public class CreateOrderDto : IMap
{
    public List<OrderItemDto> OrderItems { get; set; }
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

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrderDto, Order>();
    }
}