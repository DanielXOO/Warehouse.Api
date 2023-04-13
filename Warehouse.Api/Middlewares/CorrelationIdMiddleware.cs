using ILogger = Serilog.ILogger;

namespace Warehouse.Api.Middlewares;

public class CorrelationIdMiddleware
{
    private const string HeaderName = "X-Correlation-Id";

    private readonly RequestDelegate _next;

    private readonly ILogger _logger;

    
    public CorrelationIdMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }


    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(HeaderName, out var correlationId))
        {
            correlationId = Guid.NewGuid().ToString();

            context.Request.Headers.Add(HeaderName, correlationId);
        }
        
        _logger.Debug($"Method: {context.Request.Method} " +
                      $"Path: {context.Request.Path} CorrelationId: {correlationId} Time: {DateTime.UtcNow}");
        
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Add(HeaderName, correlationId);
            
            return Task.CompletedTask;
        });
        
        context.Response.OnCompleted(() =>
        {
            _logger.Debug($"Connection closed. CorrelationId: {correlationId} Time: {DateTime.UtcNow}");
            
            return Task.CompletedTask;
        });

        await _next(context);
    }
}