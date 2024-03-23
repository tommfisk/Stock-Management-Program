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
using DataGateway;
using DTO;

namespace Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private static readonly List<EmployeeDTO> employeeList = dataGatewayFacade.GetAllEmployees();

        public MainWindow()
        {
            InitializeComponent();
            dataGatewayFacade.InitialiseOracleDatabase();
            bindEmployeeList();
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

        private void showWindow(Type windowClass)
        {
            var window = Activator.CreateInstance(windowClass, new object[] { getEmployeeDTO() });
        }

        private void AddItemToStock_Click(object sender, RoutedEventArgs e)
        {
            if (employeeIsSelected())
            {
                AddItemToStock window = new AddItemToStock(getEmployeeDTO())
                {
                    Owner = this
                };

                window.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Please select an employee");
            }

        }

        private void AddQuantityToItem_Click(object sender, RoutedEventArgs e)
        {
            if (employeeIsSelected())
            {
                AddQuantityToItem window = new AddQuantityToItem(getEmployeeDTO())
                {
                    Owner = this
                };

                window.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Please select an employee");
            }
        }

        private void TakeQuantityFromItem_Click(object sender, RoutedEventArgs e)
        {
            if (employeeIsSelected())
            {
                TakeQuantityFromItem window = new TakeQuantityFromItem(getEmployeeDTO())
                {
                    Owner = this
                };

                window.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Please select an employee");
            }
        }

        private void ViewInventoryReport_Click(object sender, RoutedEventArgs e)
        {
            ViewInventoryReport window = new ViewInventoryReport()
            {
                Owner = this
            };

            window.ShowDialog();
        }

        private void FinancialReport_Click(object sender, RoutedEventArgs e)
        {
            ViewFinancialReport window = new ViewFinancialReport()
            {
                Owner = this
            };

            window.ShowDialog();
        }

        private void TransactionLog_Click(object sender, RoutedEventArgs e)
        {
            ViewTransactionLog window = new ViewTransactionLog()
            {
                Owner = this
            };

            window.ShowDialog();
        }

        private void PersonalUsageReport_Click(object sender, RoutedEventArgs e)
        {
            if (employeeIsSelected())
            {
                ViewPersonalUsageReport window = new ViewPersonalUsageReport(getEmployeeDTO())
                {
                    Owner = this
                };

                window.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Please select an employee");
            }
        }
    }
}