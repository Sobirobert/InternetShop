using Application.Dto;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Attributes;
using WebAPI.Functions.Commands.Picture;
using WebAPI.Functions.Commands.ProductCommnds;
using WebAPI.Functions.Queries.Picture;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiVersion("1.0")]
[Authorize(Roles = UserRoles.User)]
[ApiController]
public class PictureController(IMediator mediator) : ControllerBase
{
    [SwaggerOperation(Summary = "Retrieves all picture by unique product id")]
    [HttpGet("[action]/{productId}")]
    public async Task<IActionResult> GetPicrtureByProductId(int productId)
    {
        var query =  new GetPicrtureByProductIdQuery(productId);
        var result = await mediator.Send(query);
        return Ok(new Response<IEnumerable<PictureDto>>(result));
        
    }

    [SwaggerOperation(Summary = "Retrieves a specific picture by unique id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPictureById(int id)
    {
        var query = new GetPictureByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(new Response<PictureDto>(result));
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Add a new picture to product")]
    [HttpPost("{productId}")]
    public async Task<IActionResult> AddToProductAsync(int productId, IFormFile file)
    {
        var command = new AddPictureToProductCommand(productId, file);
        var result = await mediator.Send(command);
        return Created($"api/pictures/{result.Id}", new Response<PictureDto>(result));
    }

    [SwaggerOperation(Summary = "Sets the main picture of the product")]
    [HttpPut("[action]/{productId}/{id}")]
    public async Task<IActionResult> SetMainPicture(int productId, int id)
    {
        var command = new SetMainPictureCommand(productId, id);
        var result = await mediator.Send(command);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Delete a specific picture")]
    [HttpDelete("{productId}/{id}")]
    public async Task<IActionResult> Delate(int id)
    {
        var command = new DelateCommand(id);
        var resoult = await mediator.Send(command);
        return NoContent();
    }
}