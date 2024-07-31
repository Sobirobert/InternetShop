using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IShoppingCartItemService _shoppingCartItemService;

    public ShoppingCartController(IShoppingCartService shoppingCartService, IShoppingCartItemService shoppingCartItemService)
    {
        _shoppingCartService = shoppingCartService;
        _shoppingCartItemService = shoppingCartItemService;
    }

    [SwaggerOperation(Summary = "Find the product by Id")]
    [AllowAnonymous]
    [HttpGet("ShoppingCartItem/{id}")]
    public async Task<IActionResult> GetShoppingCartItemByID(int id)
    {
        var shoppingCart = await _shoppingCartItemService.GetShoppingCartItemById(id);
        return Ok(new Response<ShoppingCartItemDto>(shoppingCart));
    }

    [SwaggerOperation(Summary = "Find the product by Id")]
    [AllowAnonymous]
    [HttpGet("/ShoppingCart/{id}")]
    public async Task<IActionResult> GetShoppingCartByID(int id)
    {
        var shoppingCart = await _shoppingCartService.GetShoppingCartById(id);
        return Ok(new Response<ShoppingCartDto>(shoppingCart));
    }

    [SwaggerOperation(Summary = "Retrieves all Products from ShoppingCart")]
    [AllowAnonymous]
    [HttpGet("All ShoppingCartItems")]
    public async Task<IActionResult> GetAllShoppingCartItemsFromShoppingCart(int id)
    {
        var products = await _shoppingCartService.GetAllShoppingCartItems(id);

        return Ok(new Response<IEnumerable<ShoppingCartItemDto>>(products));
    }

    [SwaggerOperation(Summary = "Retrieves all ShoppingCartItems from ShoppingCart")]
    [AllowAnonymous]
    [HttpGet("All Products from ShoppingCart")]
    public async Task<IActionResult> GetAllProductsFromShoppingCart(int id)
    {
        var products = await _shoppingCartItemService.GetAllProducts(id);

        return Ok(new Response<IEnumerable<ProductDto>>(products));
    }

    [SwaggerOperation(Summary = "Get total price from ShoppingCart.")]
    [AllowAnonymous]
    [HttpGet("Total Price")]
    public async Task<IActionResult> GetTotalPriceOfShoppingCart(int id)
    {
        var productsTotalPrice = await _shoppingCartService.GetTotalPriceFromShoppingCart(id);

        return StatusCode(StatusCodes.Status200OK, new Response
        {
            Succeeded = true,
            Message = $"Your total price is = {productsTotalPrice}"
        });
    }

    [SwaggerOperation(Summary = "Create new ShoppingCart ")]
    [AllowAnonymous]
    [HttpPost("ShoppingCart")]
    public async Task<IActionResult> AddNewShoppingCart()
    {
        var createShoppingCart = await _shoppingCartService.CreateNewShoppingCart();
        return Created($"shopingCart Id = {createShoppingCart.ShoppingCartId}", new Response<ShoppingCartDto>(createShoppingCart));
    }

    [SwaggerOperation(Summary = "Add next product! ")]
    [AllowAnonymous]
    [HttpPut("ProductToShoppingCart")]
    public async Task<IActionResult> AddShoppingCartItemToShoppingCart(int productId, int shoppingCartId)
    {
        var product = await _shoppingCartItemService.GetShoppingCartItemById(productId);
        var shoppingCart = await _shoppingCartService.GetShoppingCartById(shoppingCartId);
        var createShoppingCartItem = await _shoppingCartService.AddProductToShoppingCart(product, shoppingCart);
        return Created($"shopingCart Id = {createShoppingCartItem.ShoppingCartId}", new Response<ShoppingCartDto>(createShoppingCartItem));
    }

    [SwaggerOperation(Summary = "Create new ShoppingCartItem ")]
    [AllowAnonymous]
    [HttpPost("ShoppingCartItem")]
    public async Task<IActionResult> AddNewShoppingCartItem(int productId)
    {
        var createShoppingCartItem = await _shoppingCartItemService.AddNewShoppingCartItem(productId);
        return Created($"shopingCart Id = {createShoppingCartItem.ShoppingCartId}", new Response<CreateShoppingCartItemDto>(createShoppingCartItem));
    }

    [SwaggerOperation(Summary = "Delete a ShoppingCart Item")]
    [AllowAnonymous]
    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(int id)
    {
        await _shoppingCartItemService.DeleteShioppingCartItem(id);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Remove product from shoppingCart.")]
    [AllowAnonymous]
    [HttpPut("RemoveProductFromShoppingCart")]
    public async Task<IActionResult> RemoveProductFromShoppingCartById(int productId, int shoppingCartId)
    {
        var product = await _shoppingCartItemService.GetShoppingCartItemById(productId);
        var shoppingCart = await _shoppingCartService.GetShoppingCartById(shoppingCartId);
        await _shoppingCartService.RemoveProductFromShoppingCart(product, shoppingCart);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Clear ShoppingCart")]
    [Authorize(Roles = UserRoles.Admin)]
    [HttpDelete("ClearAll")]
    public async Task<IActionResult> ClearShoppingCart(ShoppingCartDto shoppingCartDto)
    {
        await _shoppingCartItemService.ClearAllShioppingCartItems(shoppingCartDto);
        await _shoppingCartService.DeleteShoppingCart(shoppingCartDto);
        return NoContent();
    }
}