using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using TrendApi.Application.Interface.RedisCache;

namespace TrendApi.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;
        private readonly RedisCacheSetting _setting;
        public RedisCacheService(IOptions<RedisCacheSetting> options)
        {
            
            _setting = options.Value;
            var opt = ConfigurationOptions.Parse(_setting.ConnectionString);
            _connectionMultiplexer = ConnectionMultiplexer.Connect(opt);
            _database = _connectionMultiplexer.GetDatabase();
        }
        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            if(value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            TimeSpan timeUntilExpiration = expirationTime.Value -DateTime.Now;
            await _database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUntilExpiration);
        }
    }
}
