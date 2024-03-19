using DTOs;
using Entities;

namespace UseCase
{
    public class BorrowBook_UseCase : AbstractUseCase
    {

        private readonly int bookId;
        private readonly int memberId;

        public BorrowBook_UseCase(int memberId, int bookId, IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.bookId = bookId;
            this.memberId = memberId;
        }

        public override IDto Execute()
        {
            try
            {
                BookConverter bookConverter = new BookConverter();

                Book b = gatewayFacade.FindBook(bookId);

                if (b == null)
                {
                    return new MessageDTO("Book not found");
                }

                Member m = gatewayFacade.FindMember(memberId);
                if (m == null)
                {
                    return new MessageDTO("Member not found");
                }

                if (b.Borrow())
                {
                    gatewayFacade.CreateLoan(
                        new LoanBuilder()
                            .WithMember(m)
                            .WithBook(b)
                            .WithLoanDate(DateTime.Now)
                            .WithDueDate(DateTime.Now.AddDays(14))
                            .WithNumberOfRenewals(0)
                            .Build());
                    return new MessageDTO("Book borrowed");
                }
                else
                {
                    return new MessageDTO("Book not borrowed");
                }
            }
            catch (Exception e)
            {
                return new MessageDTO(e.Message);
            }
        }
    }
}
