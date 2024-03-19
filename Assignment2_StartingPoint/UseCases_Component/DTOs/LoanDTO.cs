namespace DTOs
{

    [Serializable]
    public class LoanDTO : IDto
    {
        public int ID { get; }
        public MemberDTO Member { get; }
        public BookDTO Book { get; }
        public DateTime LoanDate { get; }
        public DateTime DueDate { get; private set; }
        public DateTime ReturnDate { get; set; }
        public int NumberOfRenewals { get; private set; }

        public LoanDTO(int ID, MemberDTO m, BookDTO b, DateTime loanDate, DateTime dueDate, DateTime returnDate, int numRenewals)
        {
            this.ID = ID;
            Member = m;
            Book = b;
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
            NumberOfRenewals = numRenewals;
        }
    }
}
