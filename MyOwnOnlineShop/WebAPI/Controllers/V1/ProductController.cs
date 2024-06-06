
using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiVersion("1.0")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger _logger;
    //private readonly IMetrics _metrics;
    //private readonly IMediator _mediator;

    public ProductController(IProductService productService, IMemoryCache memoryCache, ILogger<ProductController> logger)
    {
        _productService = productService;
        _memoryCache = memoryCache;
        _logger = logger;
        //_metrics = metrics;
        //_mediator = mediator;
    }

    //[SwaggerOperation(Summary = "Retrieves sort fields")]  // Do tego jest porzebny nuget Swashbuckle.AspNetCore.Annotations
    //[HttpGet("[action]")]
    //public IActionResult GetSortFields()
    //{
    //    return Ok(/*SortingHelper.GetSortFields().Select(x => x.Key)*/);
    //}

    [SwaggerOperation(Summary = "Retrieves all Products")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var product = await _productService.GetAllPostsAsync();
        return Ok(product);
    }

    [SwaggerOperation(Summary = "Find the product by Id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostByID(int id)
    {
        var product = await _productService.GetPostByIdAsync(id);
        if (product == null)
        {
            return NotFound(id);
        }

        return Ok(product);
    }

    
    [SwaggerOperation(Summary = "Create a new post")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto newProduct)
    {
        var product = await _productService.AddNewPostAsync(newProduct);
        return Ok(product);
    }

    [SwaggerOperation(Summary = "Update a existing post")]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductDto updateProduct)
    {
        await _productService.UpdatePostAsync(updateProduct);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Delete a specific post")]
    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeletePostAsync(id);
        return NoContent();
    }
}