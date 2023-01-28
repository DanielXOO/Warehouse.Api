namespace Warehouse.Data.Repositories.Interfaces;

public interface IRepository<T> : IDisposable where T: class
{
    void Create(T data);

    void Update(T data);

    Task<T> GetByIdAsync(long id);

    void Delete(long id);
}