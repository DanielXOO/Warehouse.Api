using Microsoft.OpenApi.Models;
using Warehouse.Common.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
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

builder.Services.Configure<DbConfiguration>(builder.Configuration.GetSection("DbConfiguration"));

builder.Services.AddRouting(o => o.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();