using Entities;
using MySql.Data.MySqlClient;

namespace DatabaseGateway
{
    class FindCurrentLoanById : DatabaseSelector<Loan>
    {

        private int bookId;
        private int memberId;

        public FindCurrentLoanById(int bookId, int memberId)
        {
            this.bookId = bookId;
            this.memberId = memberId;
        }

        protected override string GetSQL()
        {
            return
                "SELECT SDAM_Loan.ID, SDAM_Loan.MemberId, SDAM_Member.Name, " +
                       "SDAM_Loan.BookId, SDAM_Book.Author, SDAM_Book.Title, SDAM_Book.ISBN, " +
                       "SDAM_Loan.LoanDate, SDAM_Loan.DueDate, SDAM_Loan.NumberOfRenewals " +
                "FROM SDAM_Loan JOIN SDAM_Member ON SDAM_Loan.MemberId = SDAM_Member.Id " +
                                "JOIN SDAM_Book ON SDAM_Loan.BookId = SDAM_Book.Id " +
                "WHERE SDAM_Loan.MemberId = @MemberId AND SDAM_Loan.BookId = @BookId AND ReturnDate IS NULL";
        }

        protected override Loan DoSelect(MySqlCommand command)
        {
            Loan foundLoan = null;

            try
            {
                command.Parameters.AddWithValue("@MemberId", memberId);
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Prepare();
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    int numRenewals = dr.IsDBNull(9) ? -1 : dr.GetInt32(9);
                    Member m =
                        new MemberBuilder()
                            .WithId(dr.GetInt32(1))
                            .WithName(dr.GetString(2))
                            .Build();
                    Book b =
                        new BookBuilder()
                            .WithId(dr.GetInt32(3))
                            .WithAuthor(dr.GetString(4))
                            .WithTitle(dr.GetString(5))
                            .WithISBN(dr.GetString(6))
                            .WithState(numRenewals)
                            .Build();
                    foundLoan =
                        new LoanBuilder()
                            .WithID(dr.GetInt32(0))
                            .WithMember(m)
                            .WithBook(b)
                            .WithLoanDate(dr.GetDateTime(7))
                            .WithDueDate(dr.GetDateTime(8))
                            .WithNumberOfRenewals(dr.GetInt32(9))
                            .Build();
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of loan failed", e);
            }

            return foundLoan;
        }
    }
}
