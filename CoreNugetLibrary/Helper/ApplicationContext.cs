using System.Data.Common;
using System.Data.SqlClient;
using SG.Kernel.DB;
using SG.Kernel.Types;

namespace SG.Kernel.Helper
{
    public class ApplicationContext
    {
        public User User { get; set; }
        public bool IsAuthenticated { get; set; }
        public DBOption DBOption { get; set; }

        public ApplicationContext()
        {
        }
        public ApplicationContext(ISqlDbLayer<SqlCommand, SqlDataReader> sqlDbLayer)
        {
            this.DBLayer = sqlDbLayer;
        }
        #region db

        public ISqlDbLayer<SqlCommand,SqlDataReader> DBLayer { get; set; }

        public ISqlDbLayer<SqlCommand, SqlDataReader> GetDBLayer()
        {
            return DBLayer;
        }

        public ISqlDbLayer<SqlCommand, SqlDataReader> GetTransactionalDBLayer()
        {
            DBLayer.BeginTransaction();
            return DBLayer;
        }

        #endregion
    }

    public class DBOption
    {
        public string DataBase { get; set; }
        public string ConnectionString { get; set; }

    }
}