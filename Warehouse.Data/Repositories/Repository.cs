using MongoDB.Driver;
using Warehouse.Data.Core;
using Warehouse.Data.Repositories.Interfaces;
using Warehouse.Entities;

namespace Warehouse.Data.Repositories;

public class Repository<T> : IRepository<T> where T: BaseObject
{
    protected readonly DbContext DbContext;

    protected readonly IMongoCollection<T> DbSet;


    public Repository(DbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = DbContext.GetCollection<T>(typeof(T).Name);
    }
    
    
    public void Dispose()
    {
        DbContext.Dispose();
    }

    public void Create(T data)
    {
        DbContext.AddCommand(() => DbSet.InsertOneAsync(data));
    }

    public void Update(T data)
    {
        DbContext.AddCommand(() =>
            DbSet.ReplaceOneAsync(o => o.Id == data.Id, data));
    }

    public async Task<T> GetByIdAsync(long id)
    {
        var document = await DbSet.FindAsync(o => o.Id == id);
        var result = await document.FirstOrDefaultAsync();

        return result;
    }

    public void Delete(long id)
    {
        DbContext.AddCommand(() => DbSet.DeleteOneAsync(o => o.Id == id));
    }
}