using Common.RestApi.Constants;
namespace Common.RestApi.Cache
{
    public interface ICustomDistributedCache
    {
        Task AddAsync(string key, object value, int expireTime = CommonConstant.DistributedCacheExpireTime);
        Task UpdateAsync(string key, object value, int expireTime = CommonConstant.DistributedCacheExpireTime);
        Task RemoveAsync(string key);
        Task<T> GetAsync<T>(string key) where T : class;
        Task<bool> IsHealthy();
    }
}
