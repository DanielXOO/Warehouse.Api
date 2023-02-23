using MediatR;

namespace Warehouse.Domain.Category.Queries;

public class GetCategoryByIdQuery : IRequest<DomainModels.Category>
{
    public long Id { get; set; }

    public GetCategoryByIdQuery(long id)
    {
        Id = id;
    }
}