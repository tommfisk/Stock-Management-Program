namespace Entities
{
    public class Loan : IEntity
    {
        public int ID { get;  }
        public Member Member { get; }
        public Book Book { get; }
        public DateTime DueDate 
        { 
            get
            {
                return state.DueDate;
            }
        }
        public DateTime LoanDate { get; }
        public int NumberOfRenewals
        {
            get
            {
                return state.NumberOfRenewals;
            }
        }
        public DateTime ReturnDate { get; set; }

        private LoanState state;

        public Loan(int ID, Member m, Book b, DateTime loanDate, DateTime returnDate, LoanState state)
        {
            this.ID = ID;
            this.Member = m;
            this.Book = b;
            this.LoanDate = loanDate;
            this.state = state;
            this.ReturnDate = returnDate;
        }

        public bool Renew()
        {
            state = state.Renew();
            return state.WasRenewed();
        }
    }
}
