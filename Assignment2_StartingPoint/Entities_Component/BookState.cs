namespace Entities
{

    // This class and its implementing classes implement the State design pattern
    public interface BookState
    {
        bool CanBorrow();

        bool CanReturn();

        BookState Borrow();

        BookState Return();
    }
}
