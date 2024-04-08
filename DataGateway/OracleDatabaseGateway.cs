using Oracle.ManagedDataAccess.Client;
using System.Data;
using System;

namespace DataGateway
{
    // Data Gateway Design Pattern
    public class OracleDatabaseGateway
    {
        private OracleDatabaseConnectionPool connectionPool;

        public OracleDatabaseGateway()
        {
            connectionPool = OracleDatabaseConnectionPool.GetInstance();
        }

        protected void CloseOracleConnection(OracleConnection conn)
        {
            connectionPool.ReleaseConnection(conn);
        }

        protected OracleConnection GetOracleConnection()
        {
            return connectionPool.AcquireConnection();
        }
    }
}