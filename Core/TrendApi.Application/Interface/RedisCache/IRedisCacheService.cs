namespace TrendApi.Application.Interface.RedisCache
{
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);
        Task<T> SetAsync<T>(string key, T value, DateTime? expirationTime = null);
    }
}
