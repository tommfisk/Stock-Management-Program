using DTOs;

namespace CommandLineUI.Presenters.Visitor
{

    class VisitableLoan : Visitable
    {
        private LoanDTO loan;
        public int ID 
        {
            get
            {
                return loan.ID;
            }
        }
        public MemberDTO Member
        {
            get
            {
                return loan.Member;
            }
        }
        public BookDTO Book
        {
            get
            {
                return loan.Book;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return loan.DueDate;
            }
        }
        public DateTime LoanDate
        {
            get
            {
                return loan.LoanDate;
            }
        }
        public int NumberOfRenewals
        {
            get
            {
                return loan.NumberOfRenewals;
            }
        }
        public DateTime ReturnDate
        {
            get
            {
                return loan.ReturnDate;
            }
        }

        public VisitableLoan(LoanDTO loan)
        {
            this.loan = loan;
        }

        public void AcceptVisitFrom(Visitor v)
        {
            v.VisitLoan(this);
        }
    }
}
