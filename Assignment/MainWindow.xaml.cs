using System.Windows;
using Assignment.Windows;
using WPF_Client;
using DTO;

namespace Assignment
{
    delegate ItemDTO GetItemDTO();
    delegate void ShowMessage(string msg);

    public partial class MainWindow : Window
    {
        private MyWPFClient client;
        private Task clientTask;


        public MainWindow()
        {
            InitializeComponent();
            client = new MyWPFClient(ShowMessage, GetItemDTO);
            clientTask = Task.Run(client.Run);
            bindEmployeeList();
        }

        private ItemDTO GetItemDTO()
        {
            return null;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        private void bindEmployeeList()
        {
            List<string> employeeNames = new List<string>();

            while (EmployeeList.ItemsSource == null)
            {
                if (client.employees != null)
                {
                    foreach (EmployeeDTO employee in client.employees)
                    {
                        employeeNames.Add(employee.Employee_Name);
                    }

                    EmployeeList.ItemsSource = employeeNames;
                }
            }
        }

        private bool employeeIsSelected()
        {
            if (EmployeeList.SelectedIndex == -1)
            {
                return false;
            }

            client.selectedEmployee = (string)EmployeeList.SelectedItem;

            return true;
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