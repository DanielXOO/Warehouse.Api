using Confluent.Kafka;
using DanielXOO.Serilog.Sinks.Kafka.Configurations;
using Serilog.Events;

namespace DanielXOO.Serilog.Sinks.Kafka.Producer;

public sealed class LogProducer : ILogProducer
{
    private readonly IProducer<string, string> _producer;
    
    
    public LogProducer(IProducer<string, string> producer)
    {
        _producer = producer;
    }
    
    
    public void Produce(LogEventLevel level, string correlationId, string message)
    {
        var kafkaMessage = new Message<string, string>
        {
            Key = correlationId,
            Value = message
        };
        
        switch (level)
        {
            case LogEventLevel.Verbose:
                _producer.Produce(KafkaSinkConfigurations.VerboseTopic, kafkaMessage);
                break;
            case LogEventLevel.Debug:
                _producer.Produce(KafkaSinkConfigurations.DebugTopic, kafkaMessage);
                break;
            case LogEventLevel.Information:
                _producer.Produce(KafkaSinkConfigurations.InformationTopic, kafkaMessage);
                break;
            case LogEventLevel.Warning:
                _producer.Produce(KafkaSinkConfigurations.WarningTopic, kafkaMessage);
                break;
            case LogEventLevel.Error:
                _producer.Produce(KafkaSinkConfigurations.ErrorTopic, kafkaMessage);
                break;
            case LogEventLevel.Fatal:
                _producer.Produce(KafkaSinkConfigurations.FatalTopic, kafkaMessage);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(level), 
                    level, "Log level not found");
        }
    }
}