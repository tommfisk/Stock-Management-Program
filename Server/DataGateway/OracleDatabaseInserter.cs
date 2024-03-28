using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace DataGateway
{
    // Interface Segregation Principle
    // Open Closed Principle
    public abstract class OracleDatabaseInserter<T>
    {

        private T itemToInsert;

        protected OracleDatabaseInserter(T itemToInsert)
        {
            this.itemToInsert = itemToInsert;
        }

        // Template design pattern
        public int Insert()
        {
            int numRowsInserted = 0;
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
                numRowsInserted = DoInsert(command, itemToInsert);
            }
            catch (Exception)
            {
                throw new Exception("ERROR: row not inserted");
            }

            connectionPool.ReleaseConnection(conn);
            return numRowsInserted;
        }

        protected abstract int DoInsert(OracleCommand command, T itemToInsert);
        protected abstract string GetSQL();
    }
}