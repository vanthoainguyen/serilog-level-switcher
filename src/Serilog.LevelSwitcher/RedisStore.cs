using System.Collections.Generic;
using StackExchange.Redis;

namespace Serilog.LevelSwitcher
{
    internal class RedisStore : IKeyValueStore
    {
        private static readonly IDictionary<string, ConnectionMultiplexer> _cache = new Dictionary<string, ConnectionMultiplexer>();

        private readonly ConnectionMultiplexer _redis;

        public RedisStore(string redisConnectionString)
        {
            if (!_cache.ContainsKey(redisConnectionString))
            {
                _cache[redisConnectionString] = ConnectionMultiplexer.Connect(redisConnectionString);
            }

            _redis = _cache[redisConnectionString];
        }

        public string Get(string key)
        {
            return _redis.GetDatabase().StringGet(key);
        }

        public void Set(string key, string value)
        {
            _redis.GetDatabase().StringSet(key, value);
        }
    }
}