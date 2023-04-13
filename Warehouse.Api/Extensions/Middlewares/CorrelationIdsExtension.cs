using Warehouse.Api.Middlewares;

namespace Warehouse.Api.Extensions.Middlewares;

public static class CorrelationIdsExtension
{
    public static void UseCorrelationIds(this WebApplication app)
    {
        app.UseMiddleware<CorrelationIdMiddleware>();
    }
}