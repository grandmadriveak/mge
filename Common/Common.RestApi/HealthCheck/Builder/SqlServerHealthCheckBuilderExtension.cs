using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Common.RestApi.Constants;
using Common.RestApi.HealthCheck.Register;

namespace Common.RestApi.HealthCheck.Builder
{
    public static class SqlServerHealthCheckBuilderExtension
    {
        public const string Name = CommonConstant.SqlServerHealthyKey;
        public static void AddSqlServerHealthCheck(this IHealthChecksBuilder builder, string connectionString, string serverType, string query, string[] tags = default, HealthStatus failedsStatus = HealthStatus.Unhealthy, TimeSpan timeOut = default)
        {
            builder.Add(new HealthCheckRegistration(Name, sp => new SqlServerHealthCheck(sp, connectionString, serverType, query), failedsStatus, tags, timeOut));
        }
    }
}
