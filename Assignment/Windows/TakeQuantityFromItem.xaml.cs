using DTO;
using System.Windows;
using WPF_Client;

namespace Assignment.Windows
{
    /// <summary>
    /// Interaction logic for TakeQuantityFromItem.xaml
    /// </summary>
    public partial class TakeQuantityFromItem : Window
    {
        private MyWPFClient client;
        
        public TakeQuantityFromItem(MyWPFClient client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void TakeQuantity_Click(object sender, RoutedEventArgs e)
        {
            RequestDTOBuilder requestDTOBuilder = new RequestDTOBuilder().WithCommand(3).WithEmployeeId(client.selectedEmployee.ID);
            ItemDTOBuilder itemDTOBuilder = new ItemDTOBuilder();
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
                ItemDTO item = itemDTOBuilder.WithID(int.Parse(ItemId.Text)).WithQuantity(int.Parse(QuantityToTake.Text)).Build();
                RequestDTO request = requestDTOBuilder.WithItem(item).Build();
                client.QueueRequest(request);
                this.Close();
            }
        }
    }
}
