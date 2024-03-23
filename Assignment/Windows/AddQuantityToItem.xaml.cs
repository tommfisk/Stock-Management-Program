using DataGateway;
using DTO;
using System.Windows;


namespace Assignment.Windows
{
    /// <summary>
    /// Interaction logic for AddQuantityToItem.xaml
    /// </summary>
    public partial class AddQuantityToItem : Window
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private EmployeeDTO employee;


        public AddQuantityToItem(EmployeeDTO employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void AddQuantity_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";

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
                if (int.Parse(QuantityToAdd.Text) < 0)
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
                MessageBox.Show(this, errorMsg, "Quantity not added", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                dataGatewayFacade.AddQuantityToItem(int.Parse(ItemId.Text), int.Parse(QuantityToAdd.Text));
                dataGatewayFacade.AddTransaction(new TransactionDTO("Quantity Added", int.Parse(ItemId.Text), employee.ID, int.Parse(QuantityToAdd.Text)));
                MessageBox.Show(this, "Quantity added");
                this.Close();
            }
        }
    }
}
