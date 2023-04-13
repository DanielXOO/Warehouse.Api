using DanielXOO.Serilog.CorrelationId.Enricher;
using DanielXOO.Serilog.Sinks.Kafka;
using DanielXOO.Serilog.Sinks.Kafka.Producer;
using Serilog;
using Serilog.Core;
using ILogger = Serilog.ILogger;

namespace Warehouse.Api.Extensions.Services;

public static class SerilogExtension
{
    public static void AddSerilog(this IServiceCollection services)
    {
        services.AddSingleton<ILogEventEnricher, CorrelationIdEnricher>();
        services.AddSingleton<ILogEventSink, KafkaSink>();
        services.AddSingleton<ILogProducer, LogProducer>();

        services.AddSingleton<ILogger>(sp =>
        {
            var enricher = sp.GetRequiredService<ILogEventEnricher>();
            var sink = sp.GetRequiredService<ILogEventSink>();

            var config = new LoggerConfiguration()
                .WriteTo.Sink(sink)
                .MinimumLevel.Debug()
                .Enrich.With(enricher);

            return config.CreateLogger();
        });
    }
}