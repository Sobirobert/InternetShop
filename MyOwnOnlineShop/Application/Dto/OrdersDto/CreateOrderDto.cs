using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.OrdersDto;
public record CreateOrderDto( List<OrderDto> OrderItems) : IMap
{
    public record AdressDto(string AddressLine1, string AddressLine2, string ZipCode, string City, string State, string Country);

    public record ContactDto(string PhoneNumber, string Email);

    public record PersonalInfoDto(string FirstName, string LastName);

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrderDto, Order>();
    }
}