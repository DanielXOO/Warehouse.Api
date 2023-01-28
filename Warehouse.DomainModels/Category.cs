namespace Warehouse.DomainModels;

public sealed class Category : BaseObject
{
    public string Name { get; set; }
    
    public string Description { get; set; }

    public int LowStockQuantity { get; set; }
    
    public int OutOfStockQuantity { get; set; }
    
    public ICollection<Product> Products { get; set; }
}