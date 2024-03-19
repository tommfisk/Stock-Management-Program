namespace Entities
{
    public interface LoanState
    {
        DateTime DueDate { get; }

        int NumberOfRenewals { get; }

        LoanState Renew();

        bool WasRenewed();
    }
}