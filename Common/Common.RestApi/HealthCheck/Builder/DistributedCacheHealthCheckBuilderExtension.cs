using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Common.RestApi.Constants;
using Common.RestApi.HealthCheck.Register;

namespace Omni.Services.HealthCheck.Builder
{
    public static class DistributedCacheHealthCheckBuilderExtension
    {
        public const string Name = CommonConstant.DistributedHealthyKey;
        public static void AddDistributedCacheHealthCheck(this IHealthChecksBuilder builder, HealthStatus failedsStatus = HealthStatus.Unhealthy, string[] tags = default, TimeSpan timeOut = default)
        {
            builder.Add(new HealthCheckRegistration(Name, sp => new DistributedCacheHealthCheck(sp), failedsStatus, tags, timeOut));
        }
    }
}
