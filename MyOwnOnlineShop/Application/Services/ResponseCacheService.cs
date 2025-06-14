using Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Application.Services;
public class ResponseCacheService(IDistributedCache distributedCache) : IResponseCacheService
{
    public async Task CacheResponse(string cacheKey, object response, TimeSpan timeLive)
    {
        if (response == null)
        {
            return;
        }

        var serializedResponse = JsonConvert.SerializeObject(response);

        await distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = timeLive
        });
    }

    public async Task<string?> GetCachedResponse(string cacheKey)
    {
        var cachedResponse = await distributedCache.GetStringAsync(cacheKey);
        return string.IsNullOrEmpty(cachedResponse) ? null : cachedResponse;
    }
}