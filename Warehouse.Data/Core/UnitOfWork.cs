using Warehouse.Data.Core.Interfaces;

namespace Warehouse.Data.Core;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbContext _dbContext;
    
    public UnitOfWork(IDbContext dbContext)
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