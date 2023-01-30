using Warehouse.Data.Entities;

namespace Warehouse.Data.Repositories.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetCategoryByNameAsync(string name);
}