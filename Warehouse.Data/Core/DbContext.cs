using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Warehouse.Common.Configurations;
using Warehouse.Data.Core.Interfaces;

namespace Warehouse.Data.Core;

public class DbContext : IDbContext
{
    private readonly IMongoDatabase _db;

    private readonly IMongoClient _mongoClient;

    private readonly List<Func<Task>> _commands;
    
    private IClientSessionHandle _session;


    public DbContext(IOptions<DbConfiguration> configuration)
    {
        _mongoClient = new MongoClient(configuration.Value.Connection);
        _db = _mongoClient.GetDatabase(configuration.Value.DbName);
        _commands = new List<Func<Task>>();
    }

    
    public void Dispose()
    {
        _session.Dispose();
        GC.SuppressFinalize(this);
    }

    public void AddCommand(Func<Task> func)
    {
        _commands.Add(func);
    }

    public async Task<int> SaveChangesAsync()
    {
        using (_session = await _mongoClient.StartSessionAsync())
        {
            _session.StartTransaction();
            
            var commandsTasks = _commands.Select(command => command());
            await Task.WhenAll(commandsTasks);
            
            await _session.CommitTransactionAsync();
        }

        return _commands.Count;
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        var collection = _db.GetCollection<T>(name);

        return collection;
    }
}