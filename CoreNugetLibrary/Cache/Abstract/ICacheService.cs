using System;
using System.Collections.Generic;

namespace SG.Kernel.Cache
{
    public interface ICacheService
    {
        List<object> GetAll(string key);
        T Get<T>(string key);
        void Set<T>(string key, T value);
    }
}
