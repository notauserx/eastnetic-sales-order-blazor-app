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
        var query = context.Orders
        .AsNoTracking()
        .Include(o => o.Windows)
            .ThenInclude(w => w.SubElements)
        .AsQueryable();

        return Ok(mapper.Map<List<OrderItem>>(await query.ToListAsync()));
    }

    [HttpPost]
    public async Task<ActionResult<OrderItem>> CreateOrderAsync(OrderItem orderItem)
    {
        var newOrder = mapper.Map<Order>(orderItem);
        context.Orders.Add(newOrder);

        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(orderItem), orderItem);
    }

    [HttpPost("{orderId}/windows")]
    public async Task<ActionResult<WindowItem>> CreateOrderWindowAsync(Guid orderId, WindowItem windowItem)
    {
        var order = await context.Orders.FirstOrDefaultAsync(i => i.Id == orderId);

        if (order == null)
        {
            return BadRequest();
        }
        var newWindow = mapper.Map<Window>(windowItem);
        newWindow.Order = order;
        context.Windows.Add(newWindow);

        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(windowItem), windowItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var order = await context.Orders
            .FirstOrDefaultAsync(i => i.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        context.Orders.Remove(order);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{orderId}/windows/{windowId}")]
    public async Task<IActionResult> DeleteOrderWindow(Guid orderId, Guid windowId)
    {
        var window = await context.Windows
            .FirstOrDefaultAsync(i => i.Id == windowId && i.OrderId == orderId);

        if (window == null)
        {
            return NotFound();
        }

        context.Windows.Remove(window);

        await context.SaveChangesAsync();

        return NoContent();
    }
}
