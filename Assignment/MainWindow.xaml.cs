using System.Windows;
using Assignment.Windows;
using WPF_Client;
using DTO;

namespace Assignment
{

    public partial class MainWindow : Window
    {
        private MyWPFClient client;
        private Task clientTask;


        public MainWindow()
        {
            InitializeComponent();
            client = new MyWPFClient();
            clientTask = Task.Run(client.Run);
            bindEmployeeList();
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

            foreach (EmployeeDTO employee in client.employees)
            {
                if (employee.Employee_Name == EmployeeList.SelectedItem)
                {
                    client.selectedEmployee = employee;
                }
            }

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
            AddItemToStock window = new AddItemToStock(client)
            {
                Owner = this
            };

            display(window);
        }

        private void AddQuantityToItem_Click(object sender, RoutedEventArgs e)
        {
            AddQuantityToItem window = new AddQuantityToItem(client)
            {
                Owner = this
            };

            display(window);
        }

        private void TakeQuantityFromItem_Click(object sender, RoutedEventArgs e)
        {
            TakeQuantityFromItem window = new TakeQuantityFromItem(client)
            {
                Owner = this
            };

            display(window);
        }

        private void ViewInventoryReport_Click(object sender, RoutedEventArgs e)
        {
            ViewInventoryReport window = new ViewInventoryReport(client)
            {
                Owner = this
            };

            display(window);
        }

        private void FinancialReport_Click(object sender, RoutedEventArgs e)
        {
            ViewFinancialReport window = new ViewFinancialReport(client)
            {
                Owner = this
            };

            display(window);
        }

        private void TransactionLog_Click(object sender, RoutedEventArgs e)
        {
            ViewTransactionLog window = new ViewTransactionLog(client)
            {
                Owner = this
            };

            display(window);
        }

        private void PersonalUsageReport_Click(object sender, RoutedEventArgs e)
        {
            ViewPersonalUsageReport window = new ViewPersonalUsageReport(client)
            {
                Owner = this
            };

            display(window);
        }
    }
}