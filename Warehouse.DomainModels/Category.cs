namespace Warehouse.DomainModels;

public class Category
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }

    public int LowStockQuantity { get; set; }
    
    public int OutOfStockQuantity { get; set; }
    
    public ICollection<Product> Products { get; set; }
}