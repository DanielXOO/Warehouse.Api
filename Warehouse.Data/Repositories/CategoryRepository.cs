using MongoDB.Driver;
using Warehouse.Data.Core;
using Warehouse.Data.Entities;
using Warehouse.Data.Repositories.Interfaces;

namespace Warehouse.Data.Repositories;

public sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(DbContext dbContext) : base(dbContext)
    {
    }

    
    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        var document = await DbSet.FindAsync(o => o.Name == name);
        var result = await document.FirstOrDefaultAsync();

        return result;
    }
}