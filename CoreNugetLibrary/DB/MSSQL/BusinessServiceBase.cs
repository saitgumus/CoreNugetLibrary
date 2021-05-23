using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace SG.Kernel.DB
{
    public abstract class BusinessServiceBase
    {
        public ISqlDbLayer<SqlCommand,SqlDataReader> DBLayer { get; set; }

        public BusinessServiceBase(ISqlDbLayer<SqlCommand, SqlDataReader> dbLayer)
        {
            DBLayer = dbLayer;
        }

        public void CommitTransaction()
        {
            DBLayer.Commit();
        }
        public void RollbackTransaction()
        {
            DBLayer.Rollback();
        }
    }
}
