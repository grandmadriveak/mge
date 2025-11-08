using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Common.RestApi.HealthCheck.Register
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        public SqlServerHealthCheck(IServiceProvider serviceProvider, string connectionString, string serverType, string query)
        {
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                bool isHealthy = true;
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
