using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Common.RestApi.Constants;
using Omni.Services.Logging;
namespace Common.RestApi.Cache
{
    public class RedisCache : ICustomDistributedCache
    {
        private readonly Seriloger _logger = Seriloger.GetInstant(typeof(RedisCache));
        private readonly IDistributedCache _distributedCache;
        public RedisCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task AddAsync(string key, object value, int expireTime = CommonConstant.DistributedCacheExpireTime)
        {
            try
            {
                await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(value), new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(expireTime)
                });
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed add cache. Message {ex.Message}", ex);
                return;
            }
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            try
            {
                var value = await _distributedCache.GetStringAsync(key);
                if (value != null)
                {
                    return JsonConvert.DeserializeObject<T>(value);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed add cache. Message {ex.Message}", ex);
                return null;
            }
        }

        public async Task<bool> IsHealthy()
        {
            try
            {
                await AddAsync(CommonConstant.DistributeKey, DateTime.Now);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed add cache. Message {ex.Message}", ex);
                return false;
            }
        }

        public async Task RemoveAsync(string key)
        {
            try
            {
                await _distributedCache.RemoveAsync(key);
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed add cache. Message {ex.Message}", ex);
                return;
            }
        }

        public async Task UpdateAsync(string key, object value, int expireTime = CommonConstant.DistributedCacheExpireTime)
        {
            try
            {
                await RemoveAsync(key);
                await AddAsync(key, value, expireTime);
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed add cache. Message {ex.Message}", ex);
                return;
            }
        }
    }
}
