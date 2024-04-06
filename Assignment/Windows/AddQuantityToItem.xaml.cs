using DTO;
using System.Windows;
using WPF_Client;


namespace Assignment.Windows
{
    /// <summary>
    /// Interaction logic for AddQuantityToItem.xaml
    /// </summary>
    public partial class AddQuantityToItem : Window
    {
        private MyWPFClient client;
        public AddQuantityToItem(MyWPFClient client)
        {
            InitializeComponent();
            this.client = client;
        }

        private async void AddQuantity_Click(object sender, RoutedEventArgs e)
        {
            const int ADD_QUANTITY_TO_ITEM = 2;
            RequestDTOBuilder requestDTOBuilder = new RequestDTOBuilder().WithCommand(ADD_QUANTITY_TO_ITEM).WithEmployeeId(client.selectedEmployee.ID);
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
                ItemDTO item = itemDTOBuilder.WithID(int.Parse(ItemId.Text)).WithQuantity(int.Parse(QuantityToAdd.Text)).Build();
                RequestDTO request = requestDTOBuilder.WithItem(item).Build();
                ResponseDTO response = await client.QueueRequest(request);

                if (response.numRowsAffected == 1)
                {
                    MessageBox.Show("Quantity Added");
                }
                else
                {
                    MessageBox.Show("Quantity Not Added");
                }
                this.Close();
            }
        }
    }
}
