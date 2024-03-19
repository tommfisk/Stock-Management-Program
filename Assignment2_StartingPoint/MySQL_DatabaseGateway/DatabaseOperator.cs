using MySql.Data.MySqlClient;
using System.Data;

namespace DatabaseGateway
{
    // This abstract class has been added to reduce duplication and shorten 
    // methods in DatabaseSelector, DatabaseInserter and DatabaseUpdater
    abstract class DatabaseOperator
    {
        protected MySqlConnection GetConnection()
        {
            return DatabaseConnectionPool.GetInstance().AcquireConnection();
        }

        protected MySqlCommand GetCommand(MySqlConnection conn)
        {
            return new MySqlCommand
            {
                Connection = conn,
                CommandText = GetSQL(),
                CommandType = CommandType.Text
            };
        }

        protected abstract string GetSQL();

        protected void ReleaseConnection(MySqlConnection conn)
        {
            DatabaseConnectionPool.GetInstance().ReleaseConnection(conn);
        }
    }
}
