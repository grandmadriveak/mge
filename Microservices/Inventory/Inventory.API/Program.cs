using Common.RestApi;
using Common.RestApi.Extension;
using Inventory.Infrastructure;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var webhost = builder.WebHost;
// Add services to the container.

services.AddControllers();
services.UpdateRuntimeContext(builder.Configuration);
services.AddDbContext<DbContext, InventoryDbContext>(options => options.UseNpgsql("Server=localhost;Database=demo;User Id=postgres;Password=1qaz2wsxE"));
services.AddMessageBus();
webhost.ConfigDynamicKestrel(builder.Configuration, RuntimeContext.CommonConfig.Microservices.InventoryPort);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
