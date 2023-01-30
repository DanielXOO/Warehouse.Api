using Warehouse.Data.Entities;

namespace Warehouse.Data.Repositories.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<Product> GetProductByNameAsync(string name);
}