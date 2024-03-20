using System.Windows;
using System.Windows.Controls;

namespace Wk11_LibraryGUI
{
    public partial class MainWindow : Window
    {
        /*private Librarian_UI libUI;
        private Member_UI memUI;

        public MainWindow()
        {
            InitializeComponent();
            InitialiseData();
            InitialiseLists();
        }

        private void InitialiseData()
        {
            BookManager bookMgr = new BookManager();
            MemberManager memberMgr = new MemberManager();
            LoanManager loanMgr = new LoanManager();

            libUI = new Librarian_UI(bookMgr, loanMgr, memberMgr);
            memUI = new Member_UI(bookMgr, loanMgr, memberMgr);

            memberMgr.AddMember(new Member(1, "Graham"));
            memberMgr.AddMember(new Member(2, "Phil"));
            memberMgr.AddMember(new Member(3, "Euan"));

            bookMgr.AddBook(new Book(1, "Author 1", "Title 1", "1234567890"));
            bookMgr.AddBook(new Book(2, "Author 2", "Title 2", "2345678901"));
            bookMgr.AddBook(new Book(3, "Author 3", "Title 3", "3456789012"));
            bookMgr.AddBook(new Book(4, "Author 4", "Title 4", "4567890123"));
        }

        private void InitialiseLists()
        {
            BookList bookList = ((BookList)Resources["BookListData"]);
            bookList.SetLibrarianUI(libUI);
            bookList.Refresh();

            LoanList loanList = ((LoanList)Resources["LoanListData"]);
            loanList.SetLibrarianUI(libUI);
            loanList.Refresh();

            MemberList memberList = ((MemberList)Resources["MemberListData"]);
            memberList.SetLibrarianUI(libUI);
            memberList.Refresh();
        }

        private void BorrowBook_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";
            if (BookListBox.SelectedIndex == -1)
            {
                errorMsg += "Please select a book\n";
            }
            if (MemberListBox.SelectedIndex == -1)
            {
                errorMsg += "Please select a member";
            }

            if (errorMsg.Length > 0)
            {
                MessageBox.Show(this, errorMsg, "Selection not made", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Book b = ((Book)BookListBox.SelectedItem);
                Member m = ((Member)MemberListBox.SelectedItem);

                memUI.BorrowBook(m.ID, b.ID);
                ((LoanList)Resources["LoanListData"]).Refresh();
            }

            BookListBox.SelectedIndex = -1;
            MemberListBox.SelectedIndex = -1;
        }

        private void RenewLoan_Click(object sender, RoutedEventArgs e)
        {
            Loan loan = ((Loan)((Button)e.Source).DataContext);
            LoanList loanList = ((LoanList)Resources["LoanListData"]);
            memUI.RenewLoan(loan.Member.ID, loan.Book.ID);
            loanList.Refresh();
        }

        private void ReturnBook_Click(object sender, RoutedEventArgs e)
        {
            Loan loan = ((Loan)((Button)e.Source).DataContext);
            LoanList loanList = ((LoanList)Resources["LoanListData"]);
            memUI.ReturnBook(loan.Member.ID, loan.Book.ID);
            loanList.Refresh();
        }

        private void BookListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }*/
    }
}
