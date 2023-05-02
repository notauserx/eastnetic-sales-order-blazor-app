using SalesOrders.Data.Entities;

namespace SalesOrders.Api.Services
{
    public interface IOrderListService
    {
        Task<IList<Order>> GetOrderItemsAsync();
    }
}