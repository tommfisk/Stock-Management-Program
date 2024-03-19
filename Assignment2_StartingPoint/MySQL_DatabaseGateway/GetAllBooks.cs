using Entities;
using Entities.State;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class GetAllBooks : DatabaseSelector<List<Book>>
    {

        public GetAllBooks()
        {

        }

        protected override string GetSQL()
        {
            return
                "SELECT SDAM_Book.ID, Author, Title, ISBN, NumberOfRenewals " +
                "FROM SDAM_Book LEFT JOIN SDAM_Loan ON SDAM_Book.Id = SDAM_Loan.BookId AND SDAM_Loan.ReturnDate is null";
        }

        protected override List<Book> DoSelect(MySqlCommand command)
        {
            List<Book> books = new List<Book>();
            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    int numRenewals = dr.IsDBNull(4) ? -1 : dr.GetInt32(4);
                    Book book =
                        new BookBuilder()
                            .WithId(dr.GetInt32(0))
                            .WithAuthor(dr.GetString(1))
                            .WithTitle(dr.GetString(2))
                            .WithISBN(dr.GetString(3))
                            .WithState(numRenewals)
                            .Build();
                    books.Add(book);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of books failed", e);
            }

            return books;
        }
    }
}
