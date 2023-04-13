using AutoMapper;

namespace Warehouse.Domain.Mapper;

public sealed class EntityProfile : Profile
{
    public EntityProfile()
    {
        CreateMap<DomainModels.Product, Data.Entities.Product>()
            .ForMember(dest => dest.CategoryId, opt
                => opt.MapFrom(src => src.Category.Id)).ReverseMap();
        
        CreateMap<DomainModels.Category, Data.Entities.Category>().ReverseMap();
    }
}