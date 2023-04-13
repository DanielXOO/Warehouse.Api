using Warehouse.Api.Middlewares;

namespace Warehouse.Api.Extensions.Middlewares;

public static class GlobalExceptionHandlerExtensions
{
    public static void UseExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}