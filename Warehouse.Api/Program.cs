using MediatR;
using Warehouse.Api.Extensions.Middlewares;
using Warehouse.Api.Extensions.Services;
using Warehouse.Domain.Product;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRouting(o => o.LowercaseUrls = true);

var mongoDbConfigs = builder.Configuration.GetSection("DbConfiguration");

builder.Services.AddMongoDb(mongoDbConfigs);
builder.Services.AddRepositories();
builder.Services.AddSwagger();
builder.Services.AddSerilog();
builder.Services.AddKafka();
builder.Services.AddAutoMapper();
builder.Services.AddMediatR(typeof(AddProductCommand).Assembly);

var app = builder.Build();

app.UseCorrelationIds();
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();