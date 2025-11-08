using Common.RestApi.Cache;
using Common.RestApi.Constants;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace Common.RestApi
{
    public interface ITenantService
    {
        void UpdateTenantConfig(Guid tenantId);
    }
    public class TenantService(IMemoryCache memoryCache, ICustomDistributedCache distributedCache) : ITenantService
    {
        public async void UpdateTenantConfig(Guid tenantId)
        {
            var tenantInfo = new TenantInfo();
            var tenantCacheKey = string.Format(CommonConstant.TenantCacheKey, tenantId);
            if (memoryCache.TryGetValue<TenantInfo>(tenantCacheKey, out var config))
            {
                tenantInfo = config;
            }
            else
            {
                var value = await distributedCache.GetAsync<TenantInfo>(tenantCacheKey);
                var expireTime = DateTime.UtcNow.AddMinutes(CommonConstant.TenantCacheKeyExpireTime);
                if (value == null)
                {
                    var commonConfig = RuntimeContext.CommonConfig.SqlServerConfig;
                    tenantInfo.TenantId = tenantId;
                    tenantInfo.ConnectionString = string.Format(commonConfig.ConnectionString, tenantId);
                    tenantInfo.AuditConnectionString = string.Format(commonConfig.AuditConnectionString, tenantId);
                    await distributedCache.AddAsync(tenantCacheKey, tenantInfo);
                }
                else
                {
                    tenantInfo.TenantId = tenantId;
                    tenantInfo.ConnectionString = value.ConnectionString;
                    tenantInfo.AuditConnectionString = value.AuditConnectionString;
                }
                memoryCache.Set(tenantCacheKey, tenantInfo, expireTime);
            }
            RuntimeContext.TenantInfo = tenantInfo;
        }
    }
}
