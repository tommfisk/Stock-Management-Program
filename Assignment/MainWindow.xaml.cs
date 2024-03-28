using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment.Windows;
using DTO;
using WPF_Client;

namespace Assignment
{

    public partial class MainWindow : Window
    {
        private static MyWPFClient client = MyWPFClient.getInstance();
        private static List<EmployeeDTO> employeeList = client.getEmployeeList();
        private Task clientTask;


        public MainWindow()
        {
            InitializeComponent();
            bindEmployeeList();
            clientTask = Task.Run(client.Run);
        }

        private void bindEmployeeList()
        {
            List<string> employeeNames = new List<string>();

            foreach (EmployeeDTO employee in employeeList)
            {
                employeeNames.Add(employee.Employee_Name);
            }

            EmployeeList.ItemsSource = employeeNames;
        }

        private bool employeeIsSelected()
        {
            if (EmployeeList.SelectedIndex == -1)
            {
                return false;
            }

            return true;
        }

        private EmployeeDTO getEmployeeDTO()
        {
            string employeeName = EmployeeList.SelectedItem.ToString();

            foreach (EmployeeDTO employee in employeeList)
            {
                if (employee.Employee_Name == employeeName) { return employee; }
            }

            return null;
        }

        private void display(Window window)
        {
            if (employeeIsSelected())
            {
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Please select an employee");
            }
        }

        private void AddItemToStock_Click(object sender, RoutedEventArgs e)
        {
            AddItemToStock window = new AddItemToStock()
            {
                Owner = this
            };

            display(window);
        }

        private void AddQuantityToItem_Click(object sender, RoutedEventArgs e)
        {
            AddQuantityToItem window = new AddQuantityToItem()
            {
                Owner = this
            };

            display(window);
        }

        private void TakeQuantityFromItem_Click(object sender, RoutedEventArgs e)
        {
            TakeQuantityFromItem window = new TakeQuantityFromItem()
            {
                Owner = this
            };

            display(window);
        }

        private void ViewInventoryReport_Click(object sender, RoutedEventArgs e)
        {
            ViewInventoryReport window = new ViewInventoryReport()
            {
                Owner = this
            };

            display(window);
        }

        private void FinancialReport_Click(object sender, RoutedEventArgs e)
        {
            ViewFinancialReport window = new ViewFinancialReport()
            {
                Owner = this
            };

            display(window);
        }

        private void TransactionLog_Click(object sender, RoutedEventArgs e)
        {
            ViewTransactionLog window = new ViewTransactionLog()
            {
                Owner = this
            };

            display(window);
        }

        private void PersonalUsageReport_Click(object sender, RoutedEventArgs e)
        {
            ViewPersonalUsageReport window = new ViewPersonalUsageReport()
            {
                Owner = this
            };

            display(window);
        }
    }
}