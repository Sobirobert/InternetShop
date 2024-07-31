
using Application.Dto.ShoppingcartItemDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
namespace Application.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
    private readonly IMapper _mapper;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper)
    {
        _mapper = mapper;
        _shoppingCartRepository = shoppingCartRepository;
        _shoppingCartItemRepository = shoppingCartItemRepository;
    }

public async Task<ShoppingCartDto> GetShoppingCartById(int cartId)
    {
        var shoppingCart = await _shoppingCartRepository.GetById(cartId);
        if (shoppingCart == null)
        {
            throw new Exception("ShoppingCart isn't exist!");
        }
        return _mapper.Map<ShoppingCartDto>(shoppingCart);
    }

    public async Task<IEnumerable<ShoppingCartItemDto>> GetAllShoppingCartItems(int cartId)
    {
        var shoppingCartItems = await _shoppingCartRepository.GetAlltems(cartId);
        if (shoppingCartItems == null)
        {
            throw new Exception("ShoppingCart isn't exist!");
        }
        return _mapper.Map<IEnumerable<ShoppingCartItemDto>>(shoppingCartItems);
    }

    public async Task<double> GetTotalPriceFromShoppingCart(int cartId)
    {
        var shoppingCartExist = await _shoppingCartRepository.GetById(cartId);
        if (shoppingCartExist == null)
        {
            throw new Exception("ShoppingCart isn't exist!");
        }
        var totalPrice = await _shoppingCartRepository.GetTotalPrice(cartId);
        return totalPrice;
    }

    public async Task DeleteShoppingCart(ShoppingCartDto shoppingCartDto)
    {
        var shoppingCartExist = await _shoppingCartRepository.GetById(shoppingCartDto.ShoppingCartId);
        if (shoppingCartExist == null)
        {
            throw new Exception("ShoppingCart isn't exist!");
        }
        var shoppingCart = _mapper.Map<ShoppingCart>(shoppingCartDto);
        await _shoppingCartRepository.Delete(shoppingCart);
    }

    public async Task<ShoppingCartDto> CreateNewShoppingCart()
    {
        var shoppingCart = await _shoppingCartRepository.CreateNew();
        return _mapper.Map<ShoppingCartDto>(shoppingCart);
    }

    public async Task<ShoppingCartDto> AddProductToShoppingCart(ShoppingCartItemDto shoppingCartItemDto, ShoppingCartDto shoppingCartDto)
    {
        var existShoppingCart = await _shoppingCartRepository.GetById(shoppingCartDto.ShoppingCartId);
        if (existShoppingCart == null)
        {
            throw new Exception("ShoppingCart isn't exist!");
        }
        var shoppingCart = _mapper.Map<ShoppingCart>(shoppingCartDto);

        var shoppingCartItemExist = await _shoppingCartItemRepository.GetById(shoppingCartItemDto.ShoppingCartItemId);
        if (shoppingCartItemExist == null)
        {
            throw new Exception("ShoppingCart Item isn't exist!");
        }
        var shoppingCartItem = _mapper.Map<ShoppingCartItem>(shoppingCartItemDto);

        await _shoppingCartRepository.AddProduct(shoppingCartItem, shoppingCart);
        return _mapper.Map<ShoppingCartDto>(shoppingCartDto);
    }

    public async Task RemoveProductFromShoppingCart(ShoppingCartItemDto shoppingCartItemDto, ShoppingCartDto shoppingCartDto)
    {
        var shoppingCartExist = await _shoppingCartRepository.GetById(shoppingCartDto.ShoppingCartId);
        if (shoppingCartExist == null)
        {
            throw new Exception("ShoppingCart isn't exist!");
        }
        var shoppingCart = _mapper.Map<ShoppingCart>(shoppingCartDto);

        var shoppingCartItemExist = await _shoppingCartItemRepository.GetById(shoppingCartItemDto.ShoppingCartItemId);
        if (shoppingCartItemExist == null)
        {
            throw new Exception("ShoppingCart Item isn't exist!");
        }
        var shoppingCartItem = _mapper.Map<ShoppingCartItem>(shoppingCartItemDto);

        await _shoppingCartRepository.RemoveProduct(shoppingCartItem, shoppingCart);
    }
}