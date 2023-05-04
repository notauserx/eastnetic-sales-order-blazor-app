using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesOrders.Contracts.Response;
using SalesOrders.Data;
using SalesOrders.Data.Entities;

namespace SalesOrders.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly SalesOrdersDbContext context;
    private readonly IMapper mapper;

    public OrdersController(
        SalesOrdersDbContext context,
        IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var orders = await context.Orders.Include(o => o.Windows).ToListAsync();

        return Ok(mapper.Map<List<OrderItem>>(orders));
    }

    [HttpPost]
    public async Task<ActionResult<OrderItem>> CreateOrderAsync(OrderItem orderItem)
    {
        var newOrder = mapper.Map<Order>(orderItem);
        context.Orders.Add(newOrder);
        
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(orderItem), orderItem);
    }

    [HttpDelete("{orderId}/windows/{windowId}")]
    public async Task<IActionResult> DeleteOrderWindow(Guid orderId, Guid windowId)
    {
        var window = await context.Windows.FirstOrDefaultAsync(i => i.Id == windowId);

        if(window == null)
        {
            return NotFound();
        }

        context.Windows.Remove(window);

        await context.SaveChangesAsync();

        return NoContent();
    }

}
