
using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ShoppingCartService : IShoppingCartService
{

    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IMapper _mapper;
    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
    {
        _mapper = mapper;
        _shoppingCartRepository = shoppingCartRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllItemsFromShoppingCartById(int shoppingCartId)
    {
        var allProducts = await _shoppingCartRepository.GetShoppingCartItems(shoppingCartId);
        return _mapper.Map<IEnumerable<ProductDto>>(allProducts);
    }

    public async Task<List<int>> GetAllShoppingCartId()
    {
        var allSchoppingCartIds = await _shoppingCartRepository.GetAllShoppingCart();
        return allSchoppingCartIds;
    }

    public async Task<double> GetTotalPriceOfShoppingCart(int shoppingCartId)
    {
        var totalPrice = await _shoppingCartRepository.GetShoppingCartTotal(shoppingCartId);
        return totalPrice;
    }
    public async Task<ShoppingCartDto> AddNewProductToShippingCart(ProductDto product, int shoppingCartId)
    {
        throw new NotImplementedException();
    }

    public async Task ClearShoppingCart(int shoppingCartId)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveProductFromShoppingCartById(ProductDto productDto, int shoppingCartId)
    {
        var product = _mapper.Map<Product>(productDto);
        await _shoppingCartRepository.RemoveFromCart(product, shoppingCartId);
    }

    //public async Task ClearCartAsync()
    //{
    //    var cartItems = _context
    //            .ShoppingCartItems
    //            .Where(cart => cart.ShoppingCartId == ShoppingCartId);

    //    _context.ShoppingCartItems.RemoveRange(cartItems);

    //    await _context.SaveChangesAsync();
    //}
    //public async Task RemoveFromCartAsync(Product product)
    //{
    //    var shoppingCartItem =
    //              await _context.ShoppingCartItems.SingleOrDefaultAsync(
    //                   s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

    //    var localAmount = 0;

    //    if (shoppingCartItem != null)
    //    {
    //        if (shoppingCartItem.Amount > 1)
    //        {
    //            shoppingCartItem.Amount--;
    //            localAmount = shoppingCartItem.Amount;
    //        }
    //        else
    //        {
    //            _context.ShoppingCartItems.Remove(shoppingCartItem);
    //        }
    //    }

    //    await _context.SaveChangesAsync();
    //}
}
