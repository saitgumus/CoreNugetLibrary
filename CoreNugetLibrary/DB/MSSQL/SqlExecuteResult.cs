using System;
using System.Data.Common;

namespace SG.Kernel.DB.MSSQL
{
    public class SqlExecuteResult<TReader> : IExecuteResult<TReader>,IDisposable
        where TReader : DbDataReader
    {
        public SqlExecuteResult()
        {
        }

    }
}
