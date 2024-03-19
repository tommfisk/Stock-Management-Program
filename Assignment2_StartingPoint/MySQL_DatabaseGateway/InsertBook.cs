using Entities;
using MySql.Data.MySqlClient;

namespace DatabaseGateway
{
    class InsertBook : DatabaseInserter<Book>
    {

        protected override string GetSQL()
        {
            return
                "INSERT INTO SDAM_Book (Author, Title, ISBN) " +
                "VALUES (@author, @title, @isbn)";
        }

        protected override int DoInsert(MySqlCommand command, Book bookToInsert)
        {
            command.Parameters.AddWithValue("@author", bookToInsert.Author);
            command.Parameters.AddWithValue("@title", bookToInsert.Title);
            command.Parameters.AddWithValue("@isbn", bookToInsert.ISBN);
            command.Prepare();
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: book not inserted");
            }
            return numRowsAffected;
        }
    }
}
