using Warehouse.Entities.Enums;

namespace Warehouse.Entities;

public class Order : BaseObject
{
    public Product Product { get; set; }

    public DateTime Date { get; set; }

    public OrderStatus Status { get; set; }
}