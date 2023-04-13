using MediatR;

namespace Warehouse.Domain.Category.Queries;

public sealed class GetCategoryByIdQuery : IRequest<DomainModels.Category>
{
    public long Id { get; set; }

    public GetCategoryByIdQuery(long id)
    {
        Id = id;
    }
}