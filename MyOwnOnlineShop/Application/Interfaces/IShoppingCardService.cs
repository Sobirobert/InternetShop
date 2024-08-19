using Application.Dto;
using Application.Dto.ShoppingcardItemDto;
using Application.Dto.ShoppingcartItemDto;
using Domain.Entities;

namespace Application.Interfaces;

public interface IShoppingCardService
{
    Task<ShoppingCardDto> GetShoppingCardById(int cardId);
    Task<IEnumerable<ShoppingCardItemDto>> GetAllShoppingCardItems(int cardId);
    Task<double> GetTotalPriceFromShoppingCard(int cardId);
    Task<ShoppingCardDto> CreateNewShoppingCard(CreateShoppingCardDto shoppingCardDto);
    Task UpdateShoppingCard(UpdateProductDto updateShoppingCard);
    Task DeleteShoppingCard(int shoppingCardId);
}