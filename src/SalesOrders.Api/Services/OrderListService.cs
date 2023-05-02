using Microsoft.EntityFrameworkCore;
using SalesOrders.Data;
using SalesOrders.Data.Entities;

namespace SalesOrders.Api.Services;

public class OrderListService : IOrderListService
{
    private readonly SalesOrdersDbContext salesOrdersDbContext;

    public OrderListService(SalesOrdersDbContext salesOrdersDbContext)
    {
        this.salesOrdersDbContext = salesOrdersDbContext;
    }
    public async Task<IList<Order>> GetOrderItemsAsync()
    {
        return await salesOrdersDbContext.Orders
            .Include(order => order.Windows).ToListAsync();
    }
}
