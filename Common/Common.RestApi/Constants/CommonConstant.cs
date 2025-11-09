namespace Common.RestApi.Constants
{
    public partial class CommonConstant
    {
        public const string TenantId = "TenantId";
        public const string DefaultTenantId = "0563d022-737c-45fc-af75-717b91f61c4b";
        public const string TenantCacheKey = "TenantId_{0}";
        public const int TenantCacheKeyExpireTime = 60;
        public const string DistributeKey = "distributed_key";
        public const int DistributedCacheExpireTime = 60;

        public const string SqlServerHealthyKey = "sqlserver_healthy";
        public const string DistributedHealthyKey = "distributed_healthy";
        public const string MessageBusHealthyKey = "messagebus_healthy";

        public const string CollerationId = "CollerationId";
        public const string Authorization = "Authorization";
    }

    public class LoggerConstant
    {
        public const string Actor = "actor";
        public const string Action = "action";
        public const string TenantId = "tenantId";
        public const string CollerationId = CommonConstant.CollerationId;
    }

    public class ClaimKeys
    {
        public const string TenantId = "tenantId";
        public const string UserId = "userId";
        public const string Email = "email";
        public const string Phone = "phone";
        public const string Username = "username";
    }

    public class CookieKeys
    {
        public const string TenantId = "tenantId";
    }
}
