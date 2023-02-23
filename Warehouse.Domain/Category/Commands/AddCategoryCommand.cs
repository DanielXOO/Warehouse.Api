using MediatR;

namespace Warehouse.Domain.Category.Commands;

public class AddCategoryCommand : IRequest<DomainModels.Category>
{
    public string Name { get; set; }
    
    public string Description { get; set; }

    public int LowStockQuantity { get; set; }
    
    public int OutOfStockQuantity { get; set; }
}