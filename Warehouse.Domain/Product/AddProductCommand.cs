using MediatR;

namespace Warehouse.Domain.Product;

public sealed class AddProductCommand : IRequest<DomainModels.Product>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int Quantity { get; set; }

    public long CategoryId { get; set; }
}