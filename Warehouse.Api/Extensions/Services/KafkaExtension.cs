using Confluent.Kafka;

namespace Warehouse.Api.Extensions.Services;

public static class KafkaExtension
{
    public static void AddKafka(this IServiceCollection services)
    {
        services.AddKafkaClient().Configure(options =>
        {
            options.Configure(new ProducerConfig
            {
                StatisticsIntervalMs = 5000
            });
        });
    }
}