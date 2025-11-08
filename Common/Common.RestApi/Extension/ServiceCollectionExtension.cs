using Common.RestApi.Builder;
using Common.RestApi.Cache;
using Common.RestApi.HealthCheck.Builder;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Omni.Services.HealthCheck.Builder;
using System.Reflection;

namespace Common.RestApi.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void UpdateRuntimeContext(this IServiceCollection services, IConfiguration configuration)
        {
            var common = new CommonConfig();
            configuration.Bind(common);

            RuntimeContext.CommonConfig = common;
        }

        public static IServiceCollection AddCommonConfig(this IServiceCollection services)
        {
            services.AddScoped<IDBRepository, DBRepository>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();

            return services;
        }

        public static IServiceCollection AddDynamicDbContext<TContextService, TContextImplementation>(this IServiceCollection services, string? connectionString, string serverType, params IInterceptor[] interceptors) where TContextImplementation : DbContext, TContextService
        {
            return services.AddDbContext<TContextService, TContextImplementation>(DbContextBuilder.Builder(serverType, connectionString, interceptors));
        }

        public static IServiceCollection AddCors(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            var redisConfig = RuntimeContext.CommonConfig.RedisCacheConfig;
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConfig.Host;
                options.ConfigurationOptions.User = redisConfig.Username;
                options.ConfigurationOptions.Password = redisConfig.Password;
            });
            services.AddScoped<ICustomDistributedCache, RedisCache>();

            return services;
        }

        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddCap(options =>
            {
                var rabbitMQ = RuntimeContext.CommonConfig.RabbitMQConfig;
                options.UseRabbitMQ(x =>
                {
                    x.HostName = rabbitMQ.Host;
                    x.Port = rabbitMQ.Port;
                    x.UserName = rabbitMQ.Username;
                    x.Password = rabbitMQ.Password;
                    x.ExchangeName = Environment.MachineName;
                }).UseEntityFramework<DbContext>();
            });

            return services;
        }

        public static void AddServerHealthCheck(this IServiceCollection services)
        {
            var builder = services.AddHealthChecks();
            builder.AddSqlServerHealthCheck(RuntimeContext.TenantInfo.ConnectionString, RuntimeContext.CommonConfig.SqlServerConfig.ServerType, "select 1;");
            builder.AddMessageBusHealthCheck();
            builder.AddDistributedCacheHealthCheck();
        }

        public static IServiceCollection RegisterSubcribers<T>(this IServiceCollection services)
        {
            var subcribers = typeof(T).Assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo(typeof(ICapSubscribe)));
            foreach (var subcriber in subcribers)
            {
                services.AddTransient(subcriber);
            }
            return services;
        }
    }
}
