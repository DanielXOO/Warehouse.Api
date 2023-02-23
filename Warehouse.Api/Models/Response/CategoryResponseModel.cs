namespace Warehouse.Api.Models.Response;

public class CategoryResponseModel
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }

    public int LowStockQuantity { get; set; }
    
    public int OutOfStockQuantity { get; set; }
    
    public IEnumerable<ProductResponseModel> Products { get; set; }
}