using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace DataGateway
{

    // Interface Segregation Principle
    // Open Closed Principle
    public abstract class OracleDatabaseSelector<T>
    {

        // Template Design Pattern
        public T Select()
        {
            T item;
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
                item = DoSelect(command);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            connectionPool.ReleaseConnection(conn);
            return item;
        }

        protected abstract T DoSelect(OracleCommand command);
        protected abstract string GetSQL();
    }
}