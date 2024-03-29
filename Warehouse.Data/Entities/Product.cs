namespace Warehouse.Data.Entities;

public sealed class Product : BaseObject
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int Quantity { get; set; }

    public long CategoryId { get; set; }
}