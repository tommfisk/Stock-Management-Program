namespace Entities.State
{

    // This class and its implementing classes implement the State design pattern
    public abstract class LoanRenewalState : LoanState
    {
        public DateTime DueDate { get; }
        public int NumberOfRenewals { get; }

        protected LoanRenewalState(int numberOfRenewals, DateTime dueDate)
        {
            NumberOfRenewals = numberOfRenewals;
            DueDate = dueDate;
        }

        public abstract LoanState Renew();

        public virtual bool WasRenewed()
        {
            return false;
        }
    }
}
