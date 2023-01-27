using Warehouse.DomainModels.Enums;

namespace Warehouse.DomainModels;

public class Order
{
    public long? Id { get; set; }

    public Product Product { get; set; }

    public DateTime Date { get; set; }

    public OrderStatus Status { get; set; }
}