using Application.Dto;
using Application.Interfaces;
using Application.Validators;
using FluentValidation;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using WebAPI.Attributes;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [SwaggerOperation(Summary = "Retrieves sort fields")]
    [HttpGet("[action]")]
    public IActionResult GetSortFields()
    {
        return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
    }

    [SwaggerOperation(Summary = "Retrieves all Products")]
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
    {
        var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
        var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

        var products = await _productService.GetAllProducts(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                                                                 validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
        var totalRecords = await _productService.GetAllProductsCount(filterBy);

        return Ok(PaginationHelper.CreatePageResponse(products, validPaginationFilter, totalRecords));
    }
    [ValidateFilter]
    [SwaggerOperation(Summary = "Find the product by Id")]
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostByID(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound(id);
        }

        return Ok(new Response<ProductDto>(product));
    }

    /// <summary>
    /// Type 0 = New,
    /// Type 1 = Used,
    /// Type 2 = Damaged
    /// </summary>
[ValidateFilter]
    [SwaggerOperation(Summary = "Create a new post")]
    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto newProduct)
    {       
        var product = await _productService.AddNewProduct(newProduct);
        return Created($"api/product/{product.Id}", new Response<ProductDto>(product));
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Update a existing Product")]
    [Authorize(Roles = UserRoles.Admin)]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductDto updateProduct)
    {
        await _productService.UpdateProduct(updateProduct);
        return NoContent();
    }
    [ValidateFilter]
    [SwaggerOperation(Summary = "Delete a specific post")]
    [Authorize(Roles = UserRoles.Admin)]
    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(int id)
    {
        var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);
        if (!isAdmin)
        {
            return BadRequest(new Response(false, "You do not own this post."));
        }
        await _productService.DeleteProduct(id);
        return NoContent();
    }
}