using System;
using System.Data.Common;

namespace APMAN.Core.DB
{
    public interface IConnectionPool<TConnection>
    {
        public TConnection Acquire(string database = "",string connectionString = "");
        public void Release(TConnection connection);

    }
}
