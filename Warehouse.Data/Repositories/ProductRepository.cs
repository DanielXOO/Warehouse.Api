using MongoDB.Driver;
using Warehouse.Data.Core;
using Warehouse.Data.Repositories.Interfaces;
using Warehouse.Entities;

namespace Warehouse.Data.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Product> GetProductByNameAsync(string name)
    {
        var document = await DbSet.FindAsync(o => o.Name == name);
        var result = await document.FirstOrDefaultAsync();

        return result;
    }
}