namespace Entities.State
{
    public class LoanStateFactory
    {
        public static LoanRenewalState Create(int numberOfRenewals, DateTime dueDate)
        {
            if (numberOfRenewals == 0)
            {
                return new NewLoan(numberOfRenewals, dueDate);
            }
            else if (numberOfRenewals < 3)
            {
                return new RenewedLoan(numberOfRenewals, dueDate);
            }
            else
            {
                return new UnrenewableLoan(numberOfRenewals, dueDate);
            }
        }
    }
}
