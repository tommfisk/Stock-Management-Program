using MySql.Data.MySqlClient;

namespace DatabaseGateway
{

    // This class and its subclasses implement the Table Data Gateway 
    // and Template Method design patterns
    abstract class DatabaseInserter<T> : DatabaseOperator, IInserter<T>
    {

        // This method is a Template Method
        public int Insert(T itemToInsert)
        {
            int numRowsInserted = 0;

            MySqlConnection conn = GetConnection();

            MySqlCommand command = GetCommand(conn);

            try
            {
                numRowsInserted = DoInsert(command, itemToInsert);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            ReleaseConnection(conn);
            return numRowsInserted;
        }

        protected abstract int DoInsert(MySqlCommand command, T itemToInsert);
        protected override abstract string GetSQL();
    }
}