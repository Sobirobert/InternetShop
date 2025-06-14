using Application.Dto.AttachmentsDto;
using Application.Interfaces;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Attributes;
using WebAPI.Functions.Commands.AttachmentCommands;
using WebAPI.Functions.Queries.AttachmentQueries;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1;

[Route("api/[controller]")]
[ApiVersion("1.0")]
[Authorize(Roles = UserRoles.Admin)]
[ApiController]
public class AttachmentsController(IMediator mediator) : ControllerBase
{
    [SwaggerOperation(Summary = "Retrieves a attachments by unique Product id")]
    [HttpGet("[action]/{productId}")]
    public async Task<IActionResult> GetByProductIdAsync(int productId)
    {
        var query = new GetAttachmentByProductIdQuery(productId);
        var result = await mediator.Send(query);
        return Ok(new Response<IEnumerable<AttachmentDto>>(result));
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Download a specific attachment by unique if")]
    [HttpGet("{productId}/{id}")]
    public async Task<IActionResult> DownloadAttachment(int id, int productId)
    {
        var query = new DownloadAttachmentQuery(id, productId);
        var result = await mediator.Send(query);
        return File(result.Content, System.Net.Mime.MediaTypeNames.Application.Octet, result.Name);
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Add a new attachment to Product")]
    [HttpPost("{productId}")]
    public async Task<IActionResult> AddToProduct(int productId, IFormFile file)
    {
        var command = new AddAttachmentToProductCommand(productId, file);
        var result = await mediator.Send(command);
        return Created($"api/attachments/{result.Id}", new Response<AttachmentDto>(result));
    }

    [SwaggerOperation(Summary = "Delete a specific attachment")]
    [HttpDelete("{productId}/{id}")]
    public async Task<IActionResult> DeleteAsync(int attachmentsId, int productId)
    {
        var command = new DeleteAttachmentCommand(attachmentsId, productId);
        var result = await mediator.Send(command);
        return NoContent();
    }
}