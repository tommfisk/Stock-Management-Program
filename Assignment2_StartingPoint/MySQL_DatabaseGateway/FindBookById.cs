using Entities;
using MySql.Data.MySqlClient;

namespace DatabaseGateway
{
    class FindBookById : DatabaseSelector<Book>
    {

        private int bookId;

        public FindBookById(int bookId)
        {
            this.bookId = bookId;
        }

        protected override string GetSQL()
        {
            return 
                "SELECT SDAM_Book.ID, Author, Title, ISBN, NumberOfRenewals " +
                "FROM SDAM_Book LEFT JOIN SDAM_Loan ON SDAM_Book.Id = SDAM_Loan.BookId AND SDAM_Loan.ReturnDate is null " +
                "WHERE SDAM_Book.id = @BookId";
        }

        protected override Book DoSelect(MySqlCommand command)
        {
            Book book = null;

            try
            {
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Prepare();
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    int numRenewals = dr.IsDBNull(4) ? -1 : dr.GetInt32(4);
                    book =
                        new BookBuilder()
                            .WithId(dr.GetInt32(0))
                            .WithAuthor(dr.GetString(1))
                            .WithTitle(dr.GetString(2))
                            .WithISBN(dr.GetString(3))
                            .WithState(numRenewals)
                            .Build();
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of book failed", e);
            }

            return book;
        }
    }
}
