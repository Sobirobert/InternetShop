using Application.Dto;
using Application.Dto.Category;
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Category;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategoriesAsync();
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var category = _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [SwaggerOperation(Summary = "Create the new Category")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.CreateCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryUpdate)
        {
            var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);
            if (!isAdmin)
            {
                return BadRequest(new Response(false, "You do not own this post."));
            }
            await _categoryService.UpdateCategoryAsync(categoryUpdate);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete the Category by Id")]
        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(int id)
        {
            var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);
            if (!isAdmin)
            {
                return BadRequest(new Response(false, "You do not own this post."));
            }
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}