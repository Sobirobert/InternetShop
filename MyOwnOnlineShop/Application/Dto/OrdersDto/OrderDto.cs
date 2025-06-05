using Application.Dto.ProductDtoFolder;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Dto.OrdersDto;
public record OrderDto(int OrderId, Guid PublicId, List<ProductDto> OrderItems, ShippingStatus ShippingStatus, PaymentStatus PaymentStatus, double OrderTotal, DateTime OrderPlaced) : IMap
{
    public record AdressDto(string AddressLine1, string AddressLine2, string ZipCode, string City, string State, string Country);

    public record ContactDto(string PhoneNumber, string Email);

    public record PersonalInfoDto(string FirstName, string LastName);

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Order, OrderDto>()
            .ForMember(dest => dest.OrderPlaced, opt => opt.MapFrom(src => src.OrderPlaced));
    }
}