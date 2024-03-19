namespace Entities.State
{
    public class BookAvailable : BookState
    {
        public BookState Borrow()
        {
            return new BookOnLoan();
        }

        public bool CanBorrow()
        {
            return true;
        }

        public bool CanReturn()
        {
            return false;
        }

        public BookState Return()
        {
            return this;
        }
        public override string ToString()
        {
            return "Available";
        }

    }
}
