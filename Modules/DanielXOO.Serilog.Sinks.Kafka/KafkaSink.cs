using DanielXOO.Serilog.Sinks.Kafka.Producer;
using Serilog.Core;
using Serilog.Events;

namespace DanielXOO.Serilog.Sinks.Kafka;

public class KafkaSink : ILogEventSink
{
    private readonly ILogProducer _logProducer;


    public KafkaSink(ILogProducer logProducer)
    {
        _logProducer = logProducer;
    }

    public void Emit(LogEvent logEvent)
    {
        if (!logEvent.Properties.TryGetValue("CorrelationId", out var value))
        {
            return;
        }
        
        var message = logEvent.RenderMessage();
        _logProducer.Produce(logEvent.Level, value.ToString(), message);
    }
}