using Application.Dto.CategoryDto;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Attributes;
using WebAPI.Functions.Commands.CategoryCommands;
using WebAPI.Functions.Queries.CategoryQueries;
using WebAPI.Models;
using WebAPI.SwaggerExamples.Responses.CategoryResponses;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1;

[Authorize(Roles = UserRoles.Admin)]
[Route("api/[controller]")]
[ApiController]
public class CategoryController(IMediator mediator) : ControllerBase
{
    [SwaggerOperation(Summary = "Show all Categories.")]
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var query = new GetAllCategoriesQuery();
        var result = await mediator.Send(query);
        return Ok(new Response<IEnumerable<CategoryDto>>(result));
    }

    /// <summary>
    /// Show all specifics from one category by id.
    /// </summary>
    [SwaggerOperation(Summary = "Show specific category by id.")]
    [HttpGet("{id}")]
    public async Task<IActionResult> DetailsSpecificCategory(int id)
    {
        var query = new DetailsSpecificCategoryQuery(id);
        var result = await mediator.Send(query);
        return Ok(new Response<CategoryDto>(result));
    }

    /// <summary>
    /// Create new category and complete description.
    /// </summary>
    [ProducesResponseType(typeof(CategoryCreateResponseStatus200), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CategoryCreateResponseStatus500), StatusCodes.Status500InternalServerError)]
    [ValidateFilter]
    [SwaggerOperation(Summary = "Create the new Category")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto categoryModelDto)
    {
        var command = new CreateCategoryCommand(
            categoryModelDto.CategoryName,
            categoryModelDto.Description
            );

        await mediator.Send(command);

        return Ok(new Response
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
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryModel categoryUpdateModel)
    {
        var command = new UpdateCategoryCommand(
               categoryUpdateModel.Id,
               categoryUpdateModel.CategoryName,
               categoryUpdateModel.Description
           );

        await mediator.Send(command);

        return Ok(new Response
        {
            Succeeded = true,
            Message = "You update category successfully."
        });
    }

    /// <summary>
    /// Delete existed category by id.
    /// </summary>
    [ProducesResponseType(typeof(CategoryResponseStatus200), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CategoryResponseStatus500), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Delete the Category by Id")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        try
        {
            var command = new DeleteCategoryCommand(id);
            await mediator.Send(command);

            return Ok(new Response
            {
                Succeeded = true,
                Message = "You deleted category."
            });
        }
        catch (ForbiddenException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, new Response(false, ex.Message));
        }
        catch (NotFoundException ex)
        {
            return BadRequest(new Response(false, ex.Message));
        }
    }
}