using AutoMapper;
using SalesOrders.Contracts.Response;
using SalesOrders.Data.Entities;

namespace SalesOrders.Api.Profiles;

public class SubElementProfile : Profile
{
    public SubElementProfile()
    {
        CreateMap<SubElement, SubElementItem>();
    }
}
