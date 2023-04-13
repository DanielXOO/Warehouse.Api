using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace DanielXOO.Serilog.CorrelationId.Enricher;

public class CorrelationIdEnricher : ILogEventEnricher
{
    private readonly IHttpContextAccessor _contextAccessor;
    

    public CorrelationIdEnricher(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
    
    
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        if (!_contextAccessor.HttpContext.Request.Headers
                .TryGetValue("X-Correlation-Id", out var correlationId))
        {
            return;
        }
        else if(!_contextAccessor.HttpContext.Request.Headers
                    .TryGetValue("X-Correlation-Id", out correlationId))
        {
            return;
        }

        var property = propertyFactory.CreateProperty("CorrelationId", correlationId);
        logEvent.AddOrUpdateProperty(property);
    }
}