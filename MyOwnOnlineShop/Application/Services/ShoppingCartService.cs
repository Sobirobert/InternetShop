
using Application.Dto;
using Application.Dto.ShoppingcardItemDto;
using Application.Dto.ShoppingcartItemDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
namespace Application.Services;

public class ShoppingCartService : IShoppingCardService
{
    private readonly IShoppingCardRepository _shoppingCartRepository;
    private readonly IShoppingCardItemRepository _shoppingCartItemRepository;
    private readonly IMapper _mapper;

    public ShoppingCartService(IShoppingCardRepository shoppingCartRepository, IShoppingCardItemRepository shoppingCartItemRepository, IMapper mapper)
    {
        _mapper = mapper;
        _shoppingCartRepository = shoppingCartRepository;
        _shoppingCartItemRepository = shoppingCartItemRepository;
    }

public async Task<ShoppingCardDto> GetShoppingCardById(int cartId)
    {
        var shoppingCart = await _shoppingCartRepository.GetById(cartId);
        return _mapper.Map<ShoppingCardDto>(shoppingCart);
    }

    public async Task<IEnumerable<ShoppingCardItemDto>> GetAllShoppingCardItems(int cartId)
    {
        var shoppingCartItems = await _shoppingCartRepository.GetAlltems(cartId);
        return _mapper.Map<IEnumerable<ShoppingCardItemDto>>(shoppingCartItems);
    }

    public async Task<double> GetTotalPriceFromShoppingCard(int cartId)
    {
        var shoppingCartExist = await _shoppingCartRepository.GetById(cartId);
        var totalPrice = await _shoppingCartRepository.GetTotalPrice(cartId);
        return totalPrice;
    }

    public async Task<ShoppingCardDto> CreateNewShoppingCard(CreateShoppingCardDto createShoppingCardDto)
    {
        var shoppingCard = _mapper.Map<ShoppingCard>(createShoppingCardDto);
        var shoppingCardDto = _mapper.Map<ShoppingCardDto>(createShoppingCardDto);
        await _shoppingCartRepository.Add(shoppingCard);
        return shoppingCardDto;
    }

    public async Task UpdateShoppingCard(UpdateProductDto updateShoppingCard)
    {
        var shoppingCardDto = _mapper.Map<ShoppingCard>(updateShoppingCard);
        await _shoppingCartRepository.Update(shoppingCardDto);
    }

    public async Task DeleteShoppingCard(int shoppingCardId)
    {
        await _shoppingCartRepository.Delete(shoppingCardId);
    }
}