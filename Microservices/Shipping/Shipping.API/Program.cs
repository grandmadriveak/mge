using Common.RestApi;
using Common.RestApi.Extension;
using Microsoft.EntityFrameworkCore;
using Shipping.Infrastructure;
using Shipping.Services.EventHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.UpdateRuntimeContext(builder.Configuration);
builder.Services.AddDbContext<DbContext, ShippingDbContext>(options => options.UseNpgsql("Server=localhost;Database=demo;User Id=postgres;Password=1qaz2wsxE"));
builder.Services.AddMessageBus();
builder.Services.RegisterSubcribers<DemoEventHandler>();
builder.WebHost.ConfigDynamicKestrel(builder.Configuration, RuntimeContext.CommonConfig.Microservices.ShippingPort);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
