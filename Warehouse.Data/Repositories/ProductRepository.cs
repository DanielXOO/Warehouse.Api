using MongoDB.Driver;
using Warehouse.Data.Core;
using Warehouse.Data.Entities;
using Warehouse.Data.Repositories.Interfaces;

namespace Warehouse.Data.Repositories;

public sealed class ProductRepository : Repository<Product>, IProductRepository
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

    public async Task<IEnumerable<Product>> GetProductsByCategoryId(long categoryId)
    {
        var document = await DbSet.FindAsync(o => o.CategoryId == categoryId);
        var result = await document.ToListAsync();

        return result;
    }
}