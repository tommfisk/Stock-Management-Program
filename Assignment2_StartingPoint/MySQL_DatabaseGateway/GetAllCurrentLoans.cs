using Entities;
using Entities.State;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class GetAllCurrentLoans : DatabaseSelector<List<Loan>>
    {

        public GetAllCurrentLoans()
        {
        }

        protected override string GetSQL()
        {
            return 
                "SELECT SDAM_Loan.ID, SDAM_Loan.MemberId, SDAM_Member.Name, " +
                        "SDAM_Loan.BookId, SDAM_Book.Author, SDAM_Book.Title, SDAM_Book.ISBN, " +
                        "SDAM_Loan.LoanDate, SDAM_Loan.DueDate, SDAM_Loan.NumberOfRenewals " +
                "FROM SDAM_Loan JOIN SDAM_Member ON SDAM_Loan.MemberId = SDAM_Member.Id " +
                               "JOIN SDAM_Book ON SDAM_Loan.BookId = SDAM_Book.Id " +
                "WHERE ReturnDate IS NULL";
        }

        // Gets all current loans
        protected override List<Loan> DoSelect(MySqlCommand command)
        {
            List<Loan> list = new List<Loan>();

            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
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
                    list.Add(new LoanBuilder()
                                .WithID(dr.GetInt32(0))
                                .WithMember(m)
                                .WithBook(b)
                                .WithLoanDate(dr.GetDateTime(7))
                                .WithDueDate(dr.GetDateTime(8))
                                .WithNumberOfRenewals(dr.GetInt32(9))
                                .Build());
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of current loans failed", e);
            }

            return list;
        }
    }
}
