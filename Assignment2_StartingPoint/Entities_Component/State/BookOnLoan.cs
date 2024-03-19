namespace Entities.State
{
    public class BookOnLoan : BookState
    {
        public BookState Borrow()
        {
            return this;
        }

        public bool CanBorrow()
        {
            return false;
        }

        public bool CanReturn()
        {
            return true;
        }

        public BookState Return()
        {
            return new BookAvailable();
        }

        public override string ToString()
        {
            return "On loan";
        }
    }
}
