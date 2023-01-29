using AutoMapper;
using Warehouse.Domain.Product;

namespace Warehouse.Domain.Mapper;

public class CommandProfile : Profile
{
    public CommandProfile()
    {
        CreateMap<AddProductCommand, Entities.Product>();
    }
}