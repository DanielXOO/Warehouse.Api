using AutoMapper;
using Warehouse.Domain.Category;
using Warehouse.Domain.Category.Commands;
using Warehouse.Domain.Product;

namespace Warehouse.Domain.Mapper;

public class CommandProfile : Profile
{
    public CommandProfile()
    {
        CreateMap<AddProductCommand, Data.Entities.Product>();
        CreateMap<AddCategoryCommand, Data.Entities.Category>();
    }
}