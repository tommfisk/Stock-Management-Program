using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace DataGateway
{

    // Interface Segregation Principle
    // Open Closed Principle
    public abstract class OracleDatabaseUpdater<T>
    {

        // Template Design Pattern
        public int Update()
        {
            int numRowsUpdated = 0;

            OracleDatabaseConnectionPool connectionPool = OracleDatabaseConnectionPool.GetInstance();
            OracleConnection conn = connectionPool.AcquireConnection();

            OracleCommand command = new OracleCommand
            {
                Connection = conn,
                CommandText = GetSQL(),
                CommandType = CommandType.Text
            };

            try
            {
                numRowsUpdated = DoUpdate(command);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            connectionPool.ReleaseConnection(conn);
            return numRowsUpdated;
        }

        protected abstract int DoUpdate(OracleCommand command);
        protected abstract string GetSQL();
    }
}