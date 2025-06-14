using Application.Dto.ProductDtoFolder;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using WebAPI.Attributes;
using WebAPI.Cache;
using WebAPI.Filters;
using WebAPI.Functions.Commands.ProductCommnds;
using WebAPI.Functions.Queries.ProductQueries;
using WebAPI.Helpers;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class ProductController(IMediator mediator) : ControllerBase
{
    [SwaggerOperation(Summary = "Retrieves sort fields")]
    [HttpGet("[action]")]
    public IActionResult GetSortFields()
    {
        return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
    }
    [Cached(600)]
    [SwaggerOperation(Summary = "Retrieves all Products")]
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
    {

        var query = new GetAllProductQuery(paginationFilter.PageNumber, paginationFilter.PageSize,
                                          sortingFilter.SortField, sortingFilter.Ascending, filterBy);

        var result = await mediator.Send(query);
        return Ok(result);
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Find the product by Id")]
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var query = new GetProductByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(new Response<ProductDto>(result));
    }

    /// <summary>
    /// Type 1 = New,
    /// Type 2 = Used,
    /// Type 3 = Damaged
    /// </summary>
    [ValidateFilter]
    [SwaggerOperation(Summary = "Create a new Product")]
    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto newProduct)
    {

        var command = new AddToProductCommand(newProduct);
        var result = await mediator.Send(command);
        return Created($"api/product/{result.Id}", new Response<ProductDto>(result));
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Update a existing Product")]
    [Authorize(Roles = UserRoles.Admin)]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductDto updateProduct)
    {
        var command = new UpdateProductCommand(updateProduct);
        var result = await mediator.Send(command);
        return NoContent();
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Delete a specific Product")]
    [Authorize(Roles = UserRoles.Admin)]
    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(int id)
    {
        var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);
        if (isAdmin)
        {
            var command = new DeleteProductCommand(id);
            var result = await mediator.Send(command);
            return NoContent();
        }
        return BadRequest(new Response(false, "You do not own this product."));
    }
}