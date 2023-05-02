using AutoMapper;
using SalesOrders.Contracts.Response;
using SalesOrders.Data.Entities;

namespace SalesOrders.Api.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderItem>();
    }

}
