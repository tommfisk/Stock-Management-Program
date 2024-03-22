using DataGateway;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment.Windows
{
    /// <summary>
    /// Interaction logic for TakeQuantityFromItem.xaml
    /// </summary>
    public partial class TakeQuantityFromItem : Window
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private static readonly List<EmployeeDTO> employeeList = dataGatewayFacade.GetAllEmployees();

        public TakeQuantityFromItem()
        {
            InitializeComponent();
            bindListBox();
        }

        private void bindListBox()
        {
            List<string> employeeNames = new List<string>();

            foreach (EmployeeDTO employee in employeeList)
            {
                employeeNames.Add(employee.Employee_Name);
            }

            EmployeeList.ItemsSource = employeeNames;
        }

        private void TakeQuantity_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";

            // employee selection validation
            if (EmployeeList.SelectedIndex == -1)
            {
                errorMsg += "Please select an employee\n";
            }

            // item id validation
            try
            {
                if (int.Parse(ItemId.Text) < 0)
                {
                    errorMsg += "Please input an item ID above 0\n";
                }
            }
            catch (Exception)
            {
                errorMsg += "Please input an item ID\n";
            }

            // item quantity validation
            try
            {
                if (int.Parse(QuantityToTake.Text) < 0)
                {
                    errorMsg += "Please input an item quantity above 0\n";
                }
            }
            catch (Exception)
            {
                errorMsg += "Please input an item quantity\n";
            }

            if (errorMsg.Length > 0)
            {
                MessageBox.Show(this, errorMsg, "Quantity not taken", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                dataGatewayFacade.TakeQuantityFromItem(int.Parse(ItemId.Text), int.Parse(QuantityToTake.Text));
                EmployeeDTO employee = dataGatewayFacade.FindEmployeeByName(EmployeeList.SelectedItem.ToString());
                dataGatewayFacade.AddTransaction(new TransactionDTO("Quantity Taken", int.Parse(ItemId.Text), employee.ID, int.Parse(QuantityToTake.Text)));
                MessageBox.Show(this, "Quantity Taken");
                this.Close();
            }

            EmployeeList.SelectedIndex = -1;
        }
    }
}
