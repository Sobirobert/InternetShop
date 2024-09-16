
using Application.Dto.OrderDto;
using Application.Interfaces;
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

[Authorize]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [SwaggerOperation(Summary = "Retrieves sort fields")]
    [HttpGet("[action]")]
    public IActionResult GetSortFields()
    {
        return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
    }

    [SwaggerOperation(Summary = "Retrieves all Orders")]
    [AllowAnonymous]
    [HttpGet("Orders")]
    public async Task<IActionResult> GetAllOrders([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
    {
        var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
        var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

        var products = await _orderService.GetAllOrders(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                                                                 validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
        var totalRecords = await _orderService.GetAllOrdersCount(filterBy);

        return Ok(PaginationHelper.CreatePageResponse(products, validPaginationFilter, totalRecords));
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Find the order by Id")]
    [AllowAnonymous]
    [HttpGet("OrderById/{id}")]
    public async Task<IActionResult> GetOrderByID(int id)
    {
        var order = await _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound(id);
        }

        return Ok(new Response<OrderDto>(order));
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Find the order by Id")]
    [AllowAnonymous]
    [HttpPost("OrderItem/Add")]
    public async Task<IActionResult> AddNewOrderItem(int orderId, int amount, int productId)
    {
        await _orderService.AddToOrder(orderId, amount, productId);
        return Ok();
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Create a new order")]
    [AllowAnonymous]
    [HttpPost("Order/Create")]
    public async Task<IActionResult> CreateNewOrder(CreateOrderDto newOrder)
    {
        var order = await _orderService.CreateOrder(newOrder);
        return Created($"api/product/{order.OrderId}", new Response<OrderDto>(order));
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Update a existing Order")]
    [AllowAnonymous]
    [HttpPut("Order/Update")]
    public async Task<IActionResult> Update(UpdateOrderDto updateOrder)
    {
        await _orderService.UpdateOrder(updateOrder);
        return NoContent();
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Update a existing OrderItem")]
    [AllowAnonymous]
    [HttpPut("OrderItem/Update")]
    public async Task<IActionResult> UpdateItem(UpdateOrderItemDto updateOrderItem)
    {
        await _orderService.UpdateOrderItem(updateOrderItem);
        return NoContent();
    }

    [ValidateFilter]
    [SwaggerOperation(Summary = "Delete a specific order")]
    [Authorize(Roles = UserRoles.Admin)]
    [HttpDelete("Order/Delete/Id")]
    public async Task<IActionResult> Delete(int id)
    {
        var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);
        if (!isAdmin)
        {
            return BadRequest(new Response(false, "You do not own this post."));
        }
        await _orderService.DeleteOrder(id);
        return NoContent();
    }
}