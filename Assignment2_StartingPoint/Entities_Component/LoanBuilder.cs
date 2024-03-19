using Entities.State;

namespace Entities
{

    // This class implements the Builder design pattern
    public class LoanBuilder
    {
        private int id;
        private Member member;
        private Book book;
        private DateTime dueDate;
        private DateTime loanDate;
        private int numberOfRenewals;
        private DateTime returnDate;

        public LoanBuilder()
        {
            this.id = -1;
            this.member = null;
            this.book = null;
        }

        public Loan Build()
        {
            return new Loan(id, member, book, loanDate, returnDate, LoanStateFactory.Create(numberOfRenewals, dueDate));
        }

        public LoanBuilder WithBook(Book b)
        {
            this.book = b;
            return this;
        }

        public LoanBuilder WithDueDate(DateTime dt)
        {
            this.dueDate = dt;
            return this;
        }

        public LoanBuilder WithID(int id)
        {
            this.id = id;
            return this;
        }

        public LoanBuilder WithLoanDate(DateTime dt)
        {
            this.loanDate = dt;
            return this;
        }

        public LoanBuilder WithMember(Member m)
        {
            this.member = m;
            return this;
        }

        public LoanBuilder WithNumberOfRenewals(int numRenewals)
        {
            this.numberOfRenewals = numRenewals;
            return this;
        }

        public LoanBuilder WithReturnDate(DateTime dt)
        {
            this.returnDate = dt;
            return this;
        }
    }
}
