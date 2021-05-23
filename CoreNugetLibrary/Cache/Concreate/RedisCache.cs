using System;
using System.Collections.Generic;
using ServiceStack;
using ServiceStack.Redis;

namespace SG.Kernel.Cache.Concreate
{
    public class RedisCache : ICacheService
    {
        public RedisCache()
        {
        }

        public T Get<T>(string key)
        {
            using (IRedisClient client = new RedisClient())
            {
                T data = client.Get<T>(key);
                return data;
            }
        }

        public List<object> GetAll(string key)
        {
            var returnObject = new List<object>();

            using (IRedisClient client = new RedisClient())
            {
                var keys = client.SearchKeys(key);
                foreach (var item in keys)
                {
                    returnObject.Add(client.Get<object>(item));
                }

            }
            return returnObject;
        }

        public void Set<T>(string key, T value)
        {
            using (IRedisClient client = new RedisClient())
            {
                var cacheData = client.As<T>();

                cacheData.SetValue(key, value);
            }
        }
    }
}
