using Common.RestApi;
using Common.RestApi.Extension;
using Inventory.Infrastructure;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.UpdateRuntimeContext(builder.Configuration);
builder.Services.AddDbContext<DbContext, InventoryDbContext>(options => options.UseNpgsql("Server=localhost;Database=demo;User Id=postgres;Password=1qaz2wsxE"));
builder.Services.AddMessageBus();
builder.WebHost.ConfigDynamicKestrel(builder.Configuration, RuntimeContext.CommonConfig.Microservices.InventoryPort);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
