using AutoMapper;
using SalesOrders.Contracts.Response;
using SalesOrders.Data.Entities;

namespace SalesOrders.Api.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderItem, Order>();
        CreateMap<Order, OrderItem>()
            .ForMember(dest => dest.State,
                       options => options.MapFrom(source => source.State.ToString()));
    }

}
