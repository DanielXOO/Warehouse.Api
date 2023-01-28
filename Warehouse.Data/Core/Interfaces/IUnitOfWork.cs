namespace Warehouse.Data.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> SaveChangesAsync();
}