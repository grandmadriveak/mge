using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Common.RestApi.Constants;
using Common.RestApi.HealthCheck.Register;

namespace Common.RestApi.HealthCheck.Builder
{
    public static class MessageBusHealthCheckBuilderExtension
    {
        private const string Name = CommonConstant.MessageBusHealthyKey;
        public static void AddMessageBusHealthCheck(this IHealthChecksBuilder builder, HealthStatus failedsStatus = HealthStatus.Unhealthy, string[] tags = default, TimeSpan timeOut = default)
        {
            builder.Add(new HealthCheckRegistration(Name, sp => new MessageBusHealthCheck(sp), failedsStatus, tags, timeOut));
        }
    }
}
