using DTOs;

namespace UseCase
{
    public class ReturnBook_UseCase : AbstractUseCase
    {
        private readonly int bookId;
        private readonly int memberId;

        public ReturnBook_UseCase(int memberId, int bookId, IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.bookId = bookId;
            this.memberId = memberId;
        }

        public override IDto Execute()
        {
            try
            {
                gatewayFacade.EndLoan(memberId, bookId);
                return new MessageDTO("Book returned");
            }
            catch (Exception e)
            {
                return new MessageDTO(e.Message);
            }
        }
    }
}
