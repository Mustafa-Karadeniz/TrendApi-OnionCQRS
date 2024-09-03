using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendApi.Application.Interface.RedisCache
{
    public interface ICacheableQuerry
    {
        string CacheKey { get; }
        double CacheTime  { get; }
    }
}
