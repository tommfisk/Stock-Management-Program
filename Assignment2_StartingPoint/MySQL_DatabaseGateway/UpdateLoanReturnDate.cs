using Entities;
using MySql.Data.MySqlClient;

namespace DatabaseGateway
{
    class UpdateLoanReturnDate : DatabaseUpdater<Loan>
    {

        protected override string GetSQL()
        {
            return
                "UPDATE SDAM_Loan " +
                "SET returnDate = @returnDate " +
                "WHERE Id = @loanId";
        }

        protected override int DoUpdate(MySqlCommand command, Loan loanToUpdate)
        {
            int numRowsAffected = 0;

            if (loanToUpdate != null)
            {
                try
                {
                    command.Parameters.AddWithValue("@returnDate", DateTime.Now);
                    command.Parameters.AddWithValue("@loanId", loanToUpdate.ID);
                    command.Prepare();
                    numRowsAffected = command.ExecuteNonQuery();

                    if (numRowsAffected != 1)
                    {
                        throw new Exception("ERROR: loan not updated");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
            return numRowsAffected;
        }
    }
}
