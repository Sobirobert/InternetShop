using Application.Dto;
using Application.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using WebAPI.Attributes;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiVersion("1.0")]
[Authorize(Roles = UserRoles.User)]
[ApiController]
public class PictureController : ControllerBase
{
    private readonly IPictureService _pictureSerwice;
    private readonly IProductService _productService;

    public PictureController(IPictureService pictureService, IProductService productService)
    {
        _pictureSerwice = pictureService;
        _productService = productService;
    }

    [SwaggerOperation(Summary = "Retrieves all picture by unique product id")]
    [HttpGet("[action]/{productId}")]
    public async Task<IActionResult> GetByPostId(int productId)
    {
        var pictures = await _pictureSerwice.GetPicturesByProductId(productId);
        return Ok(new Response<IEnumerable<PictureDto>>(pictures));
    }

    [SwaggerOperation(Summary = "Retrieves a specific picture by unique id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var picture = await _pictureSerwice.GetPictureById(id);
        if (picture == null)
        {
            return NotFound();
        }

        return Ok(new Response<PictureDto>(picture));
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Add a new picture to product")]
    [HttpPost("{productId}")]
    public async Task<IActionResult> AddToPostAsync(int productId, IFormFile file)
    {
        var product = await _productService.GetProductById(productId);
        if (product == null)
        {
            return BadRequest(new Response(false, $"Product with id {productId} does not exist."));
        }
        var picture = await _pictureSerwice.AddPictureToProduct(productId, file); 
        return Created($"api/pictures/{picture.Id}", new Response<PictureDto>(picture));
    }

    [SwaggerOperation(Summary = "Sets the main picture of the product")]
    [HttpPut("[action]/{productId}/{id}")]
    public async Task<IActionResult> SetMainPicture(int productId, int id)
    {
        await _pictureSerwice.SetMainPicture(productId, id);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Delete a specific picture")]
    [HttpDelete("{productId}/{id}")]
    public async Task<IActionResult> Delate(int id)
    {
        var userOwnsProduct = await _productService.GetProductById(id);
        if (userOwnsProduct == null)
        {
            return BadRequest(new Response(false, "Product isn't exist"));
        }

        await _pictureSerwice.DeletePicture(id);
        return NoContent();
    }
}