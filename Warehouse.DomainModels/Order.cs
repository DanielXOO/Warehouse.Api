using Warehouse.DomainModels.Enums;

namespace Warehouse.DomainModels;

public sealed class Order : BaseObject
{
    public Product Product { get; set; }

    public DateTime Date { get; set; }

    public OrderStatus Status { get; set; }
}