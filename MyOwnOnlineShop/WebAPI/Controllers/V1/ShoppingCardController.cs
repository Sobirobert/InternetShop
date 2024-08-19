using Application.Dto;
using Application.Dto.ShoppingcardItemDto;
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
public class ShoppingCardController : ControllerBase
{
    private readonly IShoppingCardService _shoppingCardService;
    private readonly IShoppingCardItemService _shoppingCardItemService;

    public ShoppingCardController(IShoppingCardService shoppingCardService, IShoppingCardItemService shoppingCardItemService)
    {
        _shoppingCardService = shoppingCardService;
        _shoppingCardItemService = shoppingCardItemService;
    }

    [SwaggerOperation(Summary = "Find the product by Id")]
    [AllowAnonymous]
    [HttpGet("ShoppingCardItem/{id}")]
    public async Task<IActionResult> GetShoppingCardItemByID(int id)
    {
        var shoppingCard = await _shoppingCardItemService.GetShoppingCardItemById(id);
        return Ok(new Response<ShoppingCardItemDto>(shoppingCard));
    }

    [SwaggerOperation(Summary = "Find the shoppingCard by Id")]
    [AllowAnonymous]
    [HttpGet("/ShoppingCard/{id}")]
    public async Task<IActionResult> GetShoppingCardByID(int id)
    {
        var shoppingCard = await _shoppingCardService.GetShoppingCardById(id);
        return Ok(new Response<ShoppingCardDto>(shoppingCard));
    }

    [SwaggerOperation(Summary = "Retrieves all Products from ShoppingCard")]
    [AllowAnonymous]
    [HttpGet("All ShoppingCardItems")]
    public async Task<IActionResult> GetAllShoppingCardItemsFromShoppingCard(int id)
    {
        var products = await _shoppingCardService.GetAllShoppingCardItems(id);

        return Ok(new Response<IEnumerable<ShoppingCardItemDto>>(products));
    }

    [SwaggerOperation(Summary = "Retrieves all ShoppingCardtems from ShoppingCard")]
    [AllowAnonymous]
    [HttpGet("All Products from ShoppingCard")]
    public async Task<IActionResult> GetAllProductsFromShoppingCard(int id)
    {
        var products = await _shoppingCardItemService.GetAllProducts(id);

        return Ok(new Response<IEnumerable<ProductDto>>(products));
    }

    [SwaggerOperation(Summary = "Get total price from ShoppingCard.")]
    [AllowAnonymous]
    [HttpGet("Total Price")]
    public async Task<IActionResult> GetTotalPriceOfShoppingCard(int id)
    {
        var productsTotalPrice = await _shoppingCardService.GetTotalPriceFromShoppingCard(id);

        return StatusCode(StatusCodes.Status200OK, new Response
        {
            Succeeded = true,
            Message = $"Your total price is = {productsTotalPrice}"
        });
    }

    [SwaggerOperation(Summary = "Create new ShoppingCard ")]
    [AllowAnonymous]
    [HttpPost("ShoppingCard")]
    public async Task<IActionResult> AddNewShoppingCard(CreateShoppingCardDto shoppingCardDto)
    {
        var createShoppingCard = await _shoppingCardService.CreateNewShoppingCard(shoppingCardDto);
        return Created($"shopingCard Id = {createShoppingCard.ShoppingCardId}", new Response<ShoppingCardDto>(createShoppingCard));
    }

    [SwaggerOperation(Summary = "Add ShoppingCardItem! ")]
    [AllowAnonymous]
    [HttpPut("ProductToShoppingCard")]
    public async Task<IActionResult> AddShoppingCardItem(int productId, int shoppingCardId)
    {
        var createShoppingCardItem = await _shoppingCardItemService.AddNewShoppingCardItem(productId, shoppingCardId);
        return Created($"shopingCard Id = {createShoppingCardItem.ShoppingCardId}", new Response<CreateShoppingCardItemDto>(createShoppingCardItem));
    }

    [SwaggerOperation(Summary = "Update new ShoppingCardItem ")]
    [AllowAnonymous]
    [HttpPost("ShoppingCardItem")]
    public async Task<IActionResult> UpdateItemFromShoppingCard(UpdateShoppingCardItemDto updateShoppingCardDto)
    {
        await _shoppingCardItemService.UpdateShoppingCardItem(updateShoppingCardDto);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Delete a ShoppingCard Item")]
    [AllowAnonymous]
    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(int id)
    {
        await _shoppingCardItemService.DeleteShioppingCardItem(id);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Clear ShoppingCard")]
    //[Authorize(Roles = UserRoles.Admin)]
    [AllowAnonymous]
    [HttpDelete("ClearAll")]
    public async Task<IActionResult> ClearShoppingCard(int shoppingCardId)
    {
        await _shoppingCardItemService.ClearAllShioppingCardItems(shoppingCardId);
        return NoContent();
    }
}