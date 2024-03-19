namespace Entities.State
{
    public class UnrenewableLoan : LoanRenewalState
    {
        private bool wasRenewed;

        public UnrenewableLoan(int numberOfRenewals, DateTime dueDate) : base(numberOfRenewals, dueDate)
        {
            wasRenewed = true;
        }

        public override LoanState Renew()
        {
            wasRenewed = false;
            return this;
        }

        public override bool WasRenewed()
        {
            return wasRenewed;
        }
    }
}