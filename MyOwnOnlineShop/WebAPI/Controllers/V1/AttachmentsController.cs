using Application.Dto.AttachmentDto;
using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using WebAPI.Attributes;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;
        private readonly IProductService _productService;

        public AttachmentsController(IAttachmentService attachmentService, IProductService productService)
        {
            _attachmentService = attachmentService;
            _productService = productService;
        }

        [SwaggerOperation(Summary = "Retrieves a attachments by unique post id")]
        [HttpGet("[action]/{productId}")]
        public async Task<IActionResult> GetByProductIdAsync(int productId)
        {
            var pictures = await _attachmentService.GetAttachmentsByProductId(productId);
            return Ok(new Response<IEnumerable<AttachmentDto>>(pictures));
        }

        [ValidateFilter]
        [SwaggerOperation(Summary = "Download a specific attachment by unique if")]
        [HttpGet("{productId}/{id}")]
        public async Task<IActionResult> DownloadAsync(int id, int productId)
        {
            var product = await _productService.GetProductById(productId);
            if (product == null)
            {
                return BadRequest(new Response(false, $"Post with id {productId} does not exist."));
            }

            var attachment = await _attachmentService.DownloadAttachmentById(id);
            if (attachment == null)
            {
                return NotFound();
            }
            return File(attachment.Content, System.Net.Mime.MediaTypeNames.Application.Octet, attachment.Name);
        }

        [ValidateFilter]
        [SwaggerOperation(Summary = "Add a new attachment to post")]
        [HttpPost("{postId}")]
        public async Task<IActionResult> AddToPostAsync(int productId, IFormFile file)
        {
            var product = await _productService.GetProductById(productId);
            if (product == null)
            {
                return BadRequest(new Response(false, $"Post with id {productId} does not exist."));
            }

            var attachment = await _attachmentService.AddAttachmentToProduct(productId, file);
            return Created($"api/attachments/{attachment.Id}", new Response<AttachmentDto>(attachment));
        }

        [SwaggerOperation(Summary = "Delete a specific attachment")]
        [HttpDelete("{postId}/{id}")]
        public async Task<IActionResult> DeleteAsync(int attachmentsId, int productId)
        {
            var product = await _productService.GetProductById(productId);
            if (product == null)
            {
                return BadRequest(new Response(false, $"Post with id {productId} does not exist."));
            }
            await _attachmentService.DelateAttachment(attachmentsId);
            return NoContent();
        }
    }
}