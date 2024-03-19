using MySql.Data.MySqlClient;

namespace DatabaseGateway
{

    // This class and its subclasses implement the Table Data Gateway 
    // and Template Method design patterns
    abstract class DatabaseSelector<T> : DatabaseOperator, ISelector<T>
    {

        // This method is a Template Method
        public T Select()
        {
            T item;

            MySqlConnection conn = GetConnection();

            MySqlCommand command = GetCommand(conn);

            try
            {
                item = DoSelect(command);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            ReleaseConnection(conn);
            return item;
        }

        protected abstract T DoSelect(MySqlCommand command);
        protected override abstract string GetSQL();
    }
}