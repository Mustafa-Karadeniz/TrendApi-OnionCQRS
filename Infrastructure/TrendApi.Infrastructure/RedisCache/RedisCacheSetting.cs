using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendApi.Infrastructure.RedisCache
{
    public class RedisCacheSetting
    {
        public string ConnectionString { get; set; }
        public string InstanceName { get; set; }
    }
}
