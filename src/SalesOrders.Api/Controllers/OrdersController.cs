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
        context.Orders.Add(mapper.Map<Order> (orderItem));
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(orderItem), orderItem);
    }
}
