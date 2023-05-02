using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SalesOrders.Api.Services;
using SalesOrders.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure dbcontext
builder.Services.AddDbContext<SalesOrdersDbContext>(
    options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("SalesOrdersDb"),
            x => x.MigrationsAssembly("SalesOrders.Data")));

// configure automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IOrderListService, OrderListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7196", "https://localhost:7196")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));

app.UseAuthorization();

app.MapControllers();

app.Run();
