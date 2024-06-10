
using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiVersion("1.0")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [SwaggerOperation(Summary = "Retrieves all Products")]
    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] PaginationFilter paginationFilter)
    {
        var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

        var products = await _productService.GetAllProductsAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize);
        var totalRecords = await _productService.GetAllProductsCountAsync();

        return Ok(PaginationHelper.CreatePageResponse(products, validPaginationFilter, totalRecords));
    }

    [SwaggerOperation(Summary = "Find the product by Id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostByID(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound(id);
        }

        return Ok(new Response<ProductDto>(product));
    }

    
    [SwaggerOperation(Summary = "Create a new post")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto newProduct)
    {
        var product = await _productService.AddNewProductAsync(newProduct);
        return Created($"api/product/{product.Id}", new Response<ProductDto>(product));
    }

    [SwaggerOperation(Summary = "Update a existing post")]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductDto updateProduct)
    {
        await _productService.UpdateProductAsync(updateProduct);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Delete a specific post")]
    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}