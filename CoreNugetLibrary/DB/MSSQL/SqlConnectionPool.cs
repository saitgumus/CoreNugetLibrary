using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using APMAN.Core.DB;
using SG.Kernel.Types;

namespace APMAN.Core.DB
{

    internal class ConnectionPool:IConnectionPool<SqlConnection>
    {
        //todo: environment / conf. içerisine taşınacak
        //const string connectionString = "Server=localhost;Database=APMAN;User Id=SA;Password=Gumus.7248;MultipleActiveResultSets=True;Connect Timeout=30";
       // const string connectionString = "Server=apmandbmain,1434;Database=APMAN;User Id=SA;Password=Apman.33;MultipleActiveResultSets=True;Connect Timeout=50";
        private static Lazy<ConnectionPool> conPool = new Lazy<ConnectionPool>(() => new ConnectionPool());
        public static ConnectionPool Instance { get; } = conPool.Value;
        private ConcurrentBag<SqlConnection> sqlConnections = new ConcurrentBag<SqlConnection>();

        private volatile int currentSize;
        private volatile int counter;
        private object lockObject = new object();
        public int size { get { return currentSize; } }

        private ConnectionPool(int size)
        {
            currentSize = size;
        }

        private ConnectionPool() : this(50)//default 50 connection
        {

        }


        /// <summary>
        /// getting a connection from pool.
        /// if not any connection usable, returned null.
        /// </summary>
        /// <returns></returns>
        public SqlConnection Acquire(string database = DataBases.APMAN,string connectionString = "")
        {
            if (!sqlConnections.TryTake(out SqlConnection connection))
            {
                lock (lockObject)
                {
                    if (connection == null)
                    {
                        if (currentSize <= counter)
                        {
                            Console.WriteLine("yeterli connection nesnesi kalmadı..");
                            throw new ApplicationException("Yeterli connection nesnesi yok.");
                        }

                        connection = new SqlConnection(connectionString);
                        counter++;
                    }
                }
            }
            else
            {
                counter++;
            }
            if (connection.Database != database && connection.State == ConnectionState.Open)
                connection.ChangeDatabase(database);
            if (connection.ConnectionString != connectionString)
                connection.ConnectionString = connectionString;

            return connection;
        }

        /// <summary>
        /// release an connection
        /// </summary>
        /// <param name="connection"></param>
        public void Release(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();

            this.sqlConnections.Add(connection);
            counter--;
        }

    }
}
