using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Common.RestApi.HealthCheck.Register
{
    public class MessageBusHealthCheck : IHealthCheck
    {
        public MessageBusHealthCheck(IServiceProvider serviceProvider)
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

                throw;
            }
        }
    }
}
