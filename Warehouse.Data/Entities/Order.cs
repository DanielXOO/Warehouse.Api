using Warehouse.Data.Entities.Enums;

namespace Warehouse.Data.Entities;

public sealed class Order : BaseObject
{
    public Product Product { get; set; }

    public DateTime Date { get; set; }

    public OrderStatus Status { get; set; }
}