namespace Application.Interfaces;

public interface IResponseCacheService
{
    Task CacheResponse(string cacheKey, object response, TimeSpan timeLive);

    Task<string?> GetCachedResponse(string cacheKey);
}