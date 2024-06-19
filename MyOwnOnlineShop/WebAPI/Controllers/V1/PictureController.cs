using Application.Dto;
using Application.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
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

    [SwaggerOperation(Summary = "Retrieves a picture by uniqe post id")]
    [HttpGet("[action]/{productId}")]
    public async Task<IActionResult> GetByPostId(int productId)
    {
        var pictures = await _pictureSerwice.GetPicturesByProductIdAsync(productId);
        return Ok(new Response<IEnumerable<PictureDto>>(pictures));
    }

    [SwaggerOperation(Summary = "Retrieves a specific picture by unique id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var picture = await _pictureSerwice.GetPictureByIdAsync(id);
        if (picture == null)
        {
            return NotFound();
        }

        return Ok(new Response<PictureDto>(picture));
    }

    [SwaggerOperation(Summary = "Add a new picture to post")]
    [HttpPost("{productId}")]
    public async Task<IActionResult> AddToPostAsync(int productId, IFormFile file)
    {
        var product = await _productService.GetProductByIdAsync(productId);
        if (product == null)
        {
            return BadRequest(new Response(false, $"Post with id {productId} does not exist."));
        }

        var userOwner = await _productService.UserOwnsProductAsync(productId, User.FindFirstValue(ClaimTypes.NameIdentifier));
        if (!userOwner)
        {
            return BadRequest(new Response(false, "You do not own this post.")); 
        }

        var picture = await _pictureSerwice.AddPictureToProductAsync(productId, file); 
        return Created($"api/pictures/{picture.Id}", new Response<PictureDto>(picture));
    }

    [SwaggerOperation(Summary = "Sets the main picture of the post")]
    [HttpPut("[action]/{productId}/{id}")]
    public async Task<IActionResult> SetMainPicture(int productId, int id)
    {
        var userOwnsProduct = await _productService.UserOwnsProductAsync(productId, User.FindFirstValue(ClaimTypes.NameIdentifier));
        if (!userOwnsProduct)
        {
            return BadRequest(new Response(false, "You do not own this post."));
        }

        await _pictureSerwice.SetMainPicture(productId, id);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Delete a specific picture")]
    [HttpDelete("{productId}/{id}")]
    public async Task<IActionResult> Delate(int id, int productId)
    {
        var userOwnsProduct = await _productService.UserOwnsProductAsync(productId, User.FindFirstValue(ClaimTypes.NameIdentifier));
        if (!userOwnsProduct)
        {
            return BadRequest(new Response(false, "You do not own this post."));
        }

        await _pictureSerwice.DeletePictureAsync(id);
        return NoContent();
    }
}