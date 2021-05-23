using System;
using System.Data.Common;
using SG.Kernel.Helper;
using SG.Kernel.Response;
using SG.Kernel.Types;

namespace SG.Kernel.DB
{
    public interface ISqlDbLayer<TCommand,TReader>
        where TReader : DbDataReader
        where TCommand : DbCommand
    {
        public TCommand GetDbCommand(string database,string commandText);
        public IExecuteResult<TReader> ExecuteReader(TCommand command);
        public Response<int> ExecuteNonQuery(TCommand command);
        public Response<object> ExecuteScalar(TCommand command);
        public void Commit();
        public void Rollback();
        public void BeginTransaction();
    }
}