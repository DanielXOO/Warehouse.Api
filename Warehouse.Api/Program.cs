using MediatR;
using Microsoft.OpenApi.Models;
using Warehouse.Common.Configurations;
using Warehouse.Data.Core;
using Warehouse.Data.Core.Interfaces;
using Warehouse.Data.Entities;
using Warehouse.Data.Repositories;
using Warehouse.Data.Repositories.Interfaces;
using Warehouse.Domain.Mapper;
using Warehouse.Domain.Product;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
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

builder.Services.AddScoped<DbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddMediatR(typeof(AddProductCommand).Assembly);
builder.Services.AddAutoMapper(c =>
{
    c.AddMaps(typeof(CommandProfile).Assembly);
});

builder.Services.Configure<DbConfiguration>(builder.Configuration.GetSection("DbConfiguration"));

builder.Services.AddRouting(o => o.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();