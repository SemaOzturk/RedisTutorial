using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisTutorial.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connection;

        public RedisCacheService(IConnectionMultiplexer connection)
        {
            _connection = connection;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            var db = _connection.GetDatabase();
           return await  db.StringGetAsync(key);//from a json string to a poco object and returns that poco object
        }

        public async Task SetCacheValueAsync(string key, string value)
        {
            var db = _connection.GetDatabase();
            await db.StringSetAsync(key, value);
        }
    }
}
