using Common.RestApi.Cache;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Common.RestApi.HealthCheck.Register
{
    public class DistributedCacheHealthCheck : IHealthCheck
    {
        private readonly ICustomDistributedCache _distributedCache;
        public DistributedCacheHealthCheck(IServiceProvider serviceProvider)
        {
            _distributedCache = serviceProvider.GetRequiredService<ICustomDistributedCache>();
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                bool isHealthy = await _distributedCache.IsHealthy();
                if (!isHealthy)
                {
                    return HealthCheckResult.Unhealthy(); 
                }
                return HealthCheckResult.Healthy();
            }
            catch (Exception)
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
