using System;
using System.Data;
using System.Data.SqlClient;
using ServiceStack;
using SG.Kernel.DB;
using SG.Kernel.DB.MSSQL;
using SG.Kernel.Helper;
using SG.Kernel.Response;
using SG.Kernel.Types;

namespace APMAN.Core.DB
{
    public class SqlDBLayer : ISqlDbLayer<SqlCommand, SqlDataReader>, IDisposable
    {

        private SqlConnection SqlConnection;

        public bool TransactionalRequest { get; set; }
        private SqlTransaction transaction;
        private string connectionString;

        public SqlDBLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }


        private void openConnection()
        {
            if (this.SqlConnection.State != ConnectionState.Open)
                SqlConnection.Open();
        }

        /// <summary>
        /// ger ideğer beklenmeyen sorgular..
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Response<int> ExecuteNonQuery(SqlCommand command)
        {
            var returnObject = new Response<int>();

            try
            {
                openConnection();
                var res = command.ExecuteNonQuery();
                returnObject.Value = res;
            }
            catch (Exception ex)
            {
                returnObject.AddResults(new Result
                {
                    ErrorMessage = ex.Message,
                    Severity = Severity.High
                });
                Rollback();
            }

            return returnObject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Response<object> ExecuteScalar(SqlCommand command)
        {
            var returnObject = new Response<object>();

            try
            {
                openConnection();
                var res = command.ExecuteScalar();
                returnObject.Value = res;
            }
            catch (Exception ex)
            {
                returnObject.AddResults(new Result
                {
                    ErrorMessage = ex.Message,
                    Severity = Severity.High
                });
                Rollback();
            }

            return returnObject;
        }

        /// <summary>
        /// execute reader
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public IExecuteResult<SqlDataReader> ExecuteReader(SqlCommand command)
        {
            var executableObject = new SqlExecuteResult<SqlDataReader>();

            try
            {
                openConnection();

                executableObject.Reader = command.ExecuteReader();
                executableObject.Success = true;
            }
            catch (Exception ex)
            {
                executableObject.Success = false;
                executableObject.Message = ex.Message;
                if (TransactionalRequest)
                    Rollback();
                command.Connection.Close();
            }
            return executableObject;

        }

        /// <summary>
        /// command nesnesi döndürülür..
        /// </summary>
        /// <param name="database"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public SqlCommand GetDbCommand(string database, string commandText)
        {
            SqlCommand cmd = null;
            if (TransactionalRequest)
                cmd = new SqlCommand(commandText, SqlConnection, transaction);
            else
            {
                SqlConnection = ConnectionPool.Instance.Acquire(database, connectionString);
                cmd = new SqlCommand(commandText, SqlConnection);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Disposed += Cmd_Disposed;
            return cmd;
        }

        /// <summary>
        /// transaction commit
        /// </summary>
        public void Commit()
        {
            if (TransactionalRequest)
            {
                transaction.Commit();
                this.Dispose();
            }
        }/// <summary>
         /// transaction rollback.
         /// </summary>
        public void Rollback()
        {
            if (TransactionalRequest)
            {
                transaction.Rollback();
                this.Dispose();
            }
        }

        #region dispose

        private void Cmd_Disposed(object sender, EventArgs e)
        {
            var command = (SqlCommand)sender;
            if (!TransactionalRequest)
                ConnectionPool.Instance.Release(command.Connection);
        }

        /// <summary>
        /// connection nesnesi geri teslim edilir.
        /// </summary>
        public void Dispose()
        {
            if (TransactionalRequest)
            {
                ConnectionPool.Instance.Release(SqlConnection);
            }
        }

        public void BeginTransaction()
        {
            if (transaction == null)
            {
                TransactionalRequest = true;
                SqlConnection = ConnectionPool.Instance.Acquire(null, connectionString);
                openConnection();
                transaction = SqlConnection.BeginTransaction();
            }
        }

        #endregion
    }
}
