using Microsoft.OpenApi.Models;

namespace Warehouse.Api.Extensions.Services;

public static class SwaggerExtension
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Warehouse.Api",
                Description = "Application demonstrating saga pattern",
                Contact = new OpenApiContact
                {
                    Name = "GitHub",
                    Url = new Uri("https://github.com/DanielXOO/")
                }
            });
        });
    }
}