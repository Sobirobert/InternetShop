using Application.Dto;
using Application.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiVersion("1.0")]
[Authorize]
[ApiController]
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

    [SwaggerOperation(Summary = "Retrieves sort fields")]  // Do tego jest porzebny nuget Swashbuckle.AspNetCore.Annotations 
    [HttpGet("[action]")]
    public IActionResult GetSortFields()
    {
        return Ok(/*SortingHelper.GetSortFields().Select(x => x.Key)*/);
    }

    [SwaggerOperation(Summary = "Retrieves all posts")]
    //[Cached(600)]
    [AllowAnonymous]
    //[Authorize(Roles = UserRoles.Admin)]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
       return Ok();
    }

    [SwaggerOperation(Summary = "Retrieves a specific post by unique Id")]
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostByID(int id)
    {
        return Ok();
    }

    //[ValidateFilter]
    [SwaggerOperation(Summary = "Create a new post")]
    [AllowAnonymous]
    //[Authorize(Roles = UserRoles.User + UserRoles.Admin + UserRoles.AdminOrUser)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto newPost)
    {
        return Ok();
    }

    [SwaggerOperation(Summary = "Update a existing post")]
    [Authorize(Roles = UserRoles.User)]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductDto updateProduct)
    {
        return Ok();
    }

    [SwaggerOperation(Summary = "Delete a specific post")]
    [Authorize(Roles = UserRoles.AdminOrUser)]
    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }
}
