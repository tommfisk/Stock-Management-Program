using Entities;
using MySql.Data.MySqlClient;

namespace DatabaseGateway
{
    class InsertLoan : DatabaseInserter<Loan>
    {

        protected override string GetSQL()
        {
            return
                "INSERT INTO SDAM_Loan (memberId, bookId, loanDate, dueDate, numberOfRenewals) " +
                "VALUES (@mId, @bId, @loanDate, @dueDate, @numRenewals)";
        }

        protected override int DoInsert(MySqlCommand command, Loan loanToInsert)
        {
            command.Parameters.AddWithValue("@mId", loanToInsert.Member.ID);
            command.Parameters.AddWithValue("@bId", loanToInsert.Book.ID);
            command.Parameters.AddWithValue("@loanDate", loanToInsert.LoanDate);
            command.Parameters.AddWithValue("@dueDate", loanToInsert.DueDate);
            command.Parameters.AddWithValue("@numRenewals", loanToInsert.NumberOfRenewals);
            command.Prepare();
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: loan not inserted");
            }
            return numRowsAffected;
        }
    }
}
