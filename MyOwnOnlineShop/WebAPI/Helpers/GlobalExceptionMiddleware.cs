using WebAPI.Wrappers;

namespace WebAPI.Helpers;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = new Response(false, exception.Message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception switch
        {
            ForbiddenException => StatusCodes.Status403Forbidden,
            NotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            ConflictException => StatusCodes.Status409Conflict, 
            _ => StatusCodes.Status500InternalServerError
        };

        _logger.LogError(exception, "An error occurred: {Message}", exception.Message);

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
