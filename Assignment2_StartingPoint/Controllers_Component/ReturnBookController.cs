using DatabaseGateway;
using DTOs;
using UseCase;

namespace Controllers
{
    public class ReturnBookController : AbstractController
    {

        private int memberId;
        private int bookId;

        public ReturnBookController(
            int memberId, 
            int bookId, 
            AbstractPresenter presenter) : base(presenter)
        {
            this.memberId = memberId;
            this.bookId = bookId;
        }

        public override IDto ExecuteUseCase()
        {
            return new ReturnBook_UseCase(memberId, bookId, new DatabaseGatewayFacade()).Execute();
        }
    }
}
