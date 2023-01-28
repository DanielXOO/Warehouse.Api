using MongoDB.Driver;

namespace Warehouse.Data.Core.Interfaces;

public interface IDbContext : IDisposable
{
    void AddCommand(Func<Task> func);

    Task<int> SaveChangesAsync();

    IMongoCollection<T> GetCollection<T>(string name);
}