namespace Entities.State
{
    public class NewLoan : LoanRenewalState
    {
        public NewLoan(int numberOfRenewals, DateTime dueDate) : base(numberOfRenewals, dueDate)
        {
        }

        public override LoanState Renew()
        {
            return LoanStateFactory.Create(NumberOfRenewals + 1, DueDate.AddDays(14));
        }
    }
}