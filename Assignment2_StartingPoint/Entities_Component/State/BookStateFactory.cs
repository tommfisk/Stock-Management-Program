namespace Entities.State
{
    public class BookStateFactory
    {
        public static BookState Create(int numberOfRenewals)
        {
            if (numberOfRenewals == -1)
            {
                return new BookAvailable();
            }
            else
            {
                return new BookOnLoan();
            }
        }

        public static BookState Create(string state)
        {
            if (state == "Available")
            {
                return new BookAvailable();
            }
            else
            {
                return new BookOnLoan();
            }
        }
    }
}
