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
        return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
    }

    [SwaggerOperation(Summary = "Retrieves all posts")]
    //[Cached(600)]
    [AllowAnonymous]
    //[Authorize(Roles = UserRoles.Admin)]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
    {
        var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
        var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

        var posts = await _postService.GetAllPostsAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                                                        validSortingFilter.SortField, validSortingFilter.Ascending,
                                                        filterBy);

        var totalRecords = await _postService.GetAllPostsCountAsync(filterBy);

        return Ok(PaginationHelper.CreatePageResponse(posts, validPaginationFilter, totalRecords));
    }


    //[SwaggerOperation(Summary = "Retrieves all posts witch cache")]
    //[EnableQuery]
    //[Authorize(Roles = UserRoles.Admin)]
    //[HttpGet("[action]")]
    //public async Task<IActionResult> GetWithCache([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
    //{
    //    var posts = _memoryCache.Get<IEnumerable<PostDto>>("posts");

    //    var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
    //    var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);
    //    if (posts == null)
    //    {                                                                         // pobieranie postów z cache służy nie do pobierania wszystkich, tylko postów z określonego czasu
    //        _logger.LogInformation("Fetching from service.");
    //        posts = await _postService.GetAllPostsAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
    //                                                   validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
    //        _memoryCache.Set("posts", posts, TimeSpan.FromMinutes(1));
    //    }
    //    else
    //    {
    //        _logger.LogInformation("Fetching from cache.");
    //    }

    //    var totalRecords = await _postService.GetAllPostsCountAsync(filterBy);
    //    return Ok(PaginationHelper.CreatePageResponse(posts, validPaginationFilter, totalRecords));
    //}

    //[SwaggerOperation(Summary = "Retrieves all posts")]
    //[Authorize(Roles = UserRoles.Admin)]
    //[HttpGet("[action]")]
    //public IQueryable<PostDto> GetAll()
    //{
    //    var posts = _memoryCache.Get<IQueryable<PostDto>>("posts");
    //    if (posts == null)
    //    {                                                                         // pobieranie postów z cache służy nie do pobierania wszystkich, tylko postów z określonego czasu
    //        _logger.LogInformation("Fetching from service.");
    //        posts = _postService.GetAllPostsAsync();
    //        _memoryCache.Set("posts", posts, TimeSpan.FromMinutes(1));
    //    }
    //    else
    //    {
    //        _logger.LogInformation("Fetching from cache.");
    //    }

    //    return posts;
    //}

    [SwaggerOperation(Summary = "Retrieves a specific post by unique Id")]
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostByID(int id)
    {
        var post = await _productService.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound(id);
        }

        return Ok(new Response<PostDto>(post));
    }

    //[ValidateFilter]
    [SwaggerOperation(Summary = "Create a new post")]
    [AllowAnonymous]
    //[Authorize(Roles = UserRoles.User + UserRoles.Admin + UserRoles.AdminOrUser)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto newPost)
    {
        //var validator = new CreatePostDtoValidator();
        //var result = validator.Validate(newPost);
        //if (!result.IsValid)
        //{
        //    return BadRequest(new Response<bool>
        //    {
        //        Succeeded = false,
        //        Message = "Something went wrong.",
        //        Errors = result.Errors.Select(x => x.ErrorMessage)
        //    });
        //}

        var post = await _productService.AddNewPostAsync(newPost, User.FindFirstValue(ClaimTypes.NameIdentifier));
        _metrics.Measure.Counter.Increment(MetricsRegistry.CreatedPostsCounter);
        return Created($"api/posts/{post.Id}", new Response<PostDto>(post));
    }

    [SwaggerOperation(Summary = "Update a existing post")]
    [Authorize(Roles = UserRoles.User)]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductDto updateProduct)
    {
        var userOwnsPost = await _productService.UserOwnsPostAsync(updatePost.Id, User.FindFirstValue(ClaimTypes.NameIdentifier));
        if (!userOwnsPost)
        {
            return BadRequest(new Response(false, "You do not own this post."));
        }

        await _productService.UpdatePostAsync(updatePost);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Delete a specific post")]
    [Authorize(Roles = UserRoles.AdminOrUser)]
    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(int id)
    {
        var userOwnsPost = await _productService.UserOwnsPostAsync(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
        var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);
        if (!isAdmin && !userOwnsPost)
        {
            return BadRequest(new Response(false, "You do not own this post."));
        }
        await _productService.DeletePostAsync(id);
        return NoContent();
    }
}
