using DatabaseGateway;
using DTOs;
using UseCase;

namespace Controllers
{
    public class BorrowBookController : AbstractController
    {

        private int memberId;
        private int bookId;

        public BorrowBookController(
            int memberId, 
            int bookId, 
            AbstractPresenter presenter) : base(presenter)
        {
            this.memberId = memberId;
            this.bookId = bookId;
        }

        public override IDto ExecuteUseCase()
        {
            return new BorrowBook_UseCase(memberId, bookId, new DatabaseGatewayFacade()).Execute();
        }
    }
}
