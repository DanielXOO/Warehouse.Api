using Warehouse.Common.Configurations;
using Warehouse.Data.Core;

namespace Warehouse.Api.Extensions.Services;

public static class MongoDbExtension
{
    public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbConfiguration>(configuration);
        services.AddScoped<DbContext>();
    }
}