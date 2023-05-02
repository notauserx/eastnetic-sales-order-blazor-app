using AutoMapper;
using SalesOrders.Contracts.Response;
using SalesOrders.Data.Entities;

namespace SalesOrders.Api.Profiles;

public class WindowsProfile : Profile
{
    public WindowsProfile()
    {
        CreateMap<Window, WindowItem>();

    }
}
