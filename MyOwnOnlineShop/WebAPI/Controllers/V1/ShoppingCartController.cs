using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    [SwaggerOperation(Summary = "Find the product by Id")]
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetShoppingCartByID(int id)
    {
        var shoppingCart = await _shoppingCartService.GetShoppingCartByID(id);
        if (shoppingCart == null)
        {
            return NotFound($"ShoppingCart isn't exist");
        }

        return Ok(new Response<ShoppingCartDto>(shoppingCart));
    }

    [SwaggerOperation(Summary = "Retrieves all Products from ShoppingCart")]
    [AllowAnonymous]
    [HttpGet()]
    public async Task<IActionResult> GetAllProductsFromShoppingCart(int id)
    {
        var products = await _shoppingCartService.GetAllItemsFromShoppingCartById(id);

        return Ok(new Response<IEnumerable<ProductDto>>(products));
    }

    [SwaggerOperation(Summary = "Retrieves all ShoppingCartItems from ShoppingCart")]
    [AllowAnonymous]
    [HttpGet("ShoppingCartItems")]
    public async Task<IActionResult> GetAllShoppingCartItems(int id)
    {
        var products = await _shoppingCartService.GetAllShoppingCartItems(id);

        return Ok(new Response<IEnumerable<ShoppingCartItemsDto>>(products));
    }

    [SwaggerOperation(Summary = "Get total price from ShoppingCart.")]
    [AllowAnonymous]
    [HttpGet("Total Price")]
    public async Task<IActionResult> GetTotalPriceOfShoppingCart(int id)
    {
        var productsTotalPrice = await _shoppingCartService.GetTotalPriceOfShoppingCart(id);

        return StatusCode(StatusCodes.Status200OK, new Response
        {
            Succeeded = true,
            Message = $"Your total price is = {productsTotalPrice}"
        });
    }

    [SwaggerOperation(Summary = "Create new ShoppingCart or add next product to exist ShoppingCart")]
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> AddNewProductToShippingCart(int productId, int shoppingCart)
    {
        var existShoppingCart = await _shoppingCartService.GetShoppingCartByID(shoppingCart);
        if (existShoppingCart == null)
        {
            existShoppingCart = await _shoppingCartService.CreateNewShoppingCart();
        }

        var createShoppingCart = await _shoppingCartService.AddNewProductToShippingCart(productId, existShoppingCart.ShoppingCartId);
        return Created($"shopingCart Id = {createShoppingCart.ShoppingCartId}, product id = {productId}", new Response<ShoppingCartDto>(createShoppingCart));
    }

    [SwaggerOperation(Summary = "Remove product from shoppingCart.")]
    [AllowAnonymous]
    [HttpPut]
    public async Task<IActionResult> RemoveProductFromShoppingCartById(int productId, int shoppingCartId)
    {
        var exitsShoppingCart = await _shoppingCartService.GetShoppingCartByID(shoppingCartId);
        if (exitsShoppingCart == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Succeeded = false,
                Message = "ShoppingCar isn't exists!"
            });
        }
        await _shoppingCartService.RemoveProductFromShoppingCartById(productId, shoppingCartId);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Clear ShoppingCart")]
    [Authorize(Roles = UserRoles.Admin)]
    [HttpDelete("Id")]
    public async Task<IActionResult> ClearShoppingCart(int id)
    {
        var exitsShoppingCart = await _shoppingCartService.GetShoppingCartByID(id);
        if (exitsShoppingCart == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Succeeded = false,
                Message = "ShoppingCar isn't exists!"
            });
        }
        await _shoppingCartService.ClearShoppingCart(id);
        return NoContent();
    }
}