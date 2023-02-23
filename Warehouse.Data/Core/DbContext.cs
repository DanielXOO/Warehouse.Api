using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Warehouse.Common.Configurations;
using Warehouse.Common.Exceptions;

namespace Warehouse.Data.Core;

public class DbContext
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
        _session?.Dispose();
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
            
            try
            {
                var commandsTasks = _commands.Select(command => command());
                await Task.WhenAll(commandsTasks);
            
                await _session.CommitTransactionAsync();
            }
            catch (Exception e)
            {
                await _session.AbortTransactionAsync();
                throw new DataException("Transaction aborted", e);
            }
        }

        return _commands.Count;
    }

    public IMongoCollection<T> GetCollection<T>(string name) where T: class
    {
        var collection = _db.GetCollection<T>(name);

        return collection;
    }
}