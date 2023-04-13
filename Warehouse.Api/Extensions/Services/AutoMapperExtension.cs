using Warehouse.Domain.Mapper;

namespace Warehouse.Api.Extensions.Services;

public static class AutoMapperExtension
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(c =>
        {
            c.AddMaps(typeof(CommandProfile).Assembly);
        });
    }
}