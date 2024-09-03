using MediatR;
using SendGrid;
using TrendApi.Application.Interface.RedisCache;

namespace TrendApi.Application.Behaviours
{
    public class RedisCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService _redisCacheService;

        public RedisCacheBehavior(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is ICacheableQuerry querry)
            {
                var cacheKey = querry.CacheKey;
                var cacheTime = querry.CacheTime;

                var cachedData = await _redisCacheService.GetAsync<TResponse>(cacheKey);
                if (cachedData != null)
                {
                    return cachedData;
                }
                
                var response = await next();
                if (response != null)
                {
                    await _redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));
                }
                return response;  
                
            }

            return await next();
        }
    }
}
