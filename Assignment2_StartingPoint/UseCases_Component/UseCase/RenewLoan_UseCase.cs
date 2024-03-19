using DTOs;
using Entities;

namespace UseCase
{
    public class RenewLoan_UseCase : AbstractUseCase
    {
        private readonly int bookId;
        private readonly int memberId;

        public RenewLoan_UseCase(int memberId, int bookId, IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.bookId = bookId;
            this.memberId = memberId;
        }

        public override IDto Execute()
        {
            Loan loan = gatewayFacade.FindLoan(memberId, bookId);

            if (loan == null)
            {
                return new MessageDTO("Loan cannot be found");
            }

            if (loan.Renew())
            {
                gatewayFacade.RenewLoan(loan);
                return new MessageDTO("Loan has been renewed");
            }
            else
            {
                return new MessageDTO("Loan cannot be renewed");
            }
        }
    }
}
