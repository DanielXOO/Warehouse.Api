using AutoMapper;

namespace Warehouse.Domain.Mapper;

public class EntityProfile : Profile
{
    public EntityProfile()
    {
        CreateMap<DomainModels.Product, Entities.Product>()
            .ForMember(dest => dest.CategoryId, opt
                => opt.MapFrom(src => src.Category.Id)).ReverseMap();
    }
}