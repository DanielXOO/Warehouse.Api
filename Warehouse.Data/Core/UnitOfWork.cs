using Warehouse.Data.Core.Interfaces;

namespace Warehouse.Data.Core;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _dbContext;
    
    public UnitOfWork(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public async Task<bool> SaveChangesAsync()
    {
        var  rows = await _dbContext.SaveChangesAsync();

        return rows > 0;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}