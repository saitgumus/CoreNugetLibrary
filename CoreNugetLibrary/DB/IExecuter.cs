using System;
using System.Data;

namespace SG.Kernel.DB
{
    public class IExecuteResult<Treader> : IDisposable
        where Treader : System.Data.Common.DbDataReader
    {
        public Treader Reader;
        public int ExecuteNonQuery { get; set; }
        public bool Success;
        public string Message;

        public IExecuteResult()
        {

        }
        public void Dispose()
        {
            //todo: dispose işlemler yapılcak
            if (Reader != null && !Reader.IsClosed)
                Reader.Close();
        }
    }


    public class IExecuteScalarResult<T> : IDisposable
    {
        public int ExecuteNonQuery { get; set; }
        public bool Success;
        public string Message;

        public void Dispose()
        {
        }
    }
}