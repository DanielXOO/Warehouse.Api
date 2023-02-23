using Warehouse.DomainModels.Enums;

namespace Warehouse.Api.Models.Response;

public class ProductResponseModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int Quantity { get; set; }

    public CategoryResponseModel Category { get; set; }

    public StockStatus StockStatus;
}