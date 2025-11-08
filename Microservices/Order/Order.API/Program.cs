using Common.RestApi;
using Common.RestApi.Constants;
using Common.RestApi.Extension;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.UpdateRuntimeContext(builder.Configuration);
builder.Services.AddDbContext<DbContext, OrderDbContext>(options => options.UseNpgsql("Server=localhost;Database=demo;User Id=postgres;Password=1qaz2wsxE"));
//builder.Services.AddDynamicDbContext<DbContext, OrderDbContext>(RuntimeContext.CommonConfig.SqlServerConfig.ConnectionString, RuntimeContext.CommonConfig.SqlServerConfig.ServerType);
builder.Services.AddMessageBus();
builder.WebHost.ConfigDynamicKestrel(builder.Configuration, RuntimeContext.CommonConfig.Microservices.OrderPort);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
