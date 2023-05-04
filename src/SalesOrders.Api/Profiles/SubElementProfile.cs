using AutoMapper;
using SalesOrders.Contracts.Response;
using SalesOrders.Data.Entities;

namespace SalesOrders.Api.Profiles;

public class SubElementProfile : Profile
{
    public SubElementProfile()
    {
        CreateMap<SubElementItem, SubElement>();
        CreateMap<SubElement, SubElementItem>()
            .ForMember(dest => dest.Type,
                       options => options.MapFrom(source => source.Type.ToString()));
    }
}
