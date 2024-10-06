using Application.Dto.CategoryDto;
using Application.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using WebAPI.Models;
using WebAPI.SwaggerExamples.Responses.CategoryResponses;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [SwaggerOperation(Summary = "Show all Categories.")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            if (categories == null)
            {
                return BadRequest(new Response(false, "Categories are empty"));
            }

            return Ok(new Response<IEnumerable<CategoryDto>>(categories));
        }

        /// <summary>
        /// Show all specifics from one category by id.
        /// </summary>
        [SwaggerOperation(Summary = "Show specific category by id.")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            category.totalRecords = await _categoryService.GetProductsCount(id);
            return Ok(new Response<CategoryDto>(category));
        }

        /// <summary>
        /// Create new category and complete description.
        /// </summary>
        [ProducesResponseType(typeof(CategoryCreateResponseStatus200), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CategoryCreateResponseStatus500), StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Create the new Category")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto categoryModelDto)
        {
            CreateCategoryDto createCategoryDto = new CreateCategoryDto()
            {
                CategoryName = categoryModelDto.CategoryName,
                Description = categoryModelDto.Description,
            };


            var categoryExists = await _categoryService.GetCategoryByName(createCategoryDto.CategoryName);
            if (categoryExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Succeeded = false,
                    Message = "Category already exists!"
                });
            }

            await _categoryService.CreateCategory(createCategoryDto);

            return StatusCode(StatusCodes.Status200OK, new Response
            {
                Succeeded = true,
                Message = "Category created!"
            });
        }

        /// <summary>
        /// Update existed category.
        /// </summary>
        [ProducesResponseType(typeof(CategoryResponseStatus200), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CategoryResponseStatus500), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryModel categoryUpdateModel)
        {
            var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);
            if (!isAdmin)
            {
                return BadRequest(new Response(false, "You can't change category."));
            }
            else
            {
                UpdateCategoryDto updateCategoryDto = new UpdateCategoryDto()
                {
                    Id = categoryUpdateModel.Id,
                    CategoryName = categoryUpdateModel.CategoryName,
                    Description = categoryUpdateModel.Description
                };

                await _categoryService.GetCategoryById(updateCategoryDto.Id);
                if (updateCategoryDto.CategoryName == null)
                {
                    return BadRequest(new Response(false, "Category isn't exists!"));
                }

                await _categoryService.UpdateCategory(updateCategoryDto);
                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    Succeeded = true,
                    Message = "You update category successfully."
                });
            }
        }

        /// <summary>
        /// Delete existed category by id.
        /// </summary>
        [ProducesResponseType(typeof(CategoryResponseStatus200), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CategoryResponseStatus500), StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Delete the Category by Id")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);
            if (isAdmin == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Succeeded = false,
                    Message = "You aren't Admin! Only Admin can delete Category"
                });
            }
            else
            {
                var existCategory = await _categoryService.GetCategoryById(id);
                if (existCategory == null)
                {
                    return BadRequest(new Response(false, "Category isn't exists!"));
                }
                await _categoryService.DeleteCategory(id);
                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    Succeeded = true,
                    Message = "You deleted category."
                });
            }
        }
    }
}