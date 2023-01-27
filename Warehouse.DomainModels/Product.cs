using Warehouse.DomainModels.Enums;

namespace Warehouse.DomainModels;

public class Product
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Quantity { get; set; }

    public Category Category { get; set; }

    public StockStatus StockStatus
    {
        get
        {
            if (Quantity <= Category.OutOfStockQuantity)
            {
                return StockStatus.OutOfStock;
            }

            if(Quantity <= Category.LowStockQuantity)
            {
                return StockStatus.LowStock;
            }

            return StockStatus.InStock;
        }
    }
}