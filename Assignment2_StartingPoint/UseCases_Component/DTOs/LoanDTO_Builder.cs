namespace DTOs
{

    public class LoanDTO_Builder
    {
        private int id;
        private MemberDTO member;
        private BookDTO book;
        private DateTime loanDate;
        private DateTime dueDate;
        private DateTime returnDate;
        private int numberOfRenewals;

        public LoanDTO_Builder()
        {
            id = -1;
            member = null;
            book = null;
            loanDate = DateTime.MinValue;
            dueDate = DateTime.MinValue;
            returnDate = DateTime.MinValue;
            numberOfRenewals = -1;
        }

        public LoanDTO Build()
        {
            return new LoanDTO(id, member, book, loanDate, dueDate, returnDate, numberOfRenewals);
        }

        public LoanDTO_Builder WithBook(BookDTO b)
        {
            this.book = b;
            return this;
        }

        public LoanDTO_Builder WithDueDate(DateTime dt)
        {
            this.dueDate = dt;
            return this;
        }

        public LoanDTO_Builder WithID(int id)
        {
            this.id = id;
            return this;
        }

        public LoanDTO_Builder WithLoanDate(DateTime dt)
        {
            this.loanDate = dt;
            return this;
        }

        public LoanDTO_Builder WithMember(MemberDTO m)
        {
            this.member = m;
            return this;
        }

        public LoanDTO_Builder WithNumberOfRenewals(int numRenewals)
        {
            this.numberOfRenewals = numRenewals;
            return this;
        }

        public LoanDTO_Builder WithReturnDate(DateTime dt)
        {
            this.returnDate = dt;
            return this;
        }
    }
}
