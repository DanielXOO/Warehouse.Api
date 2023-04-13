using Warehouse.Data.Core;
using Warehouse.Data.Core.Interfaces;
using Warehouse.Data.Repositories;
using Warehouse.Data.Repositories.Interfaces;

namespace Warehouse.Api.Extensions.Services;

public static class RepositoriesExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}