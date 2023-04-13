using Serilog.Events;

namespace DanielXOO.Serilog.Sinks.Kafka.Producer;

public interface ILogProducer
{
    void Produce(LogEventLevel level, string correlationId, string message);
}