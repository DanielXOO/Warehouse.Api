namespace Warehouse.Api.Middlewares;

public class CorrelationIdMiddleware
{
    private const string HeaderName = "X-Correlation-Id";

    private readonly RequestDelegate _next;

    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(HeaderName, out var correlationId))
        {
            correlationId = Guid.NewGuid().ToString();
            context.Request.Headers.Add(HeaderName, correlationId);
        }
        
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Add(HeaderName, correlationId);
            
            return Task.CompletedTask;
        });

        await _next(context);
    }
}