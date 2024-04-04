using DTO;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Client;

namespace Assignment.Windows
{
    /// <summary>
    /// Interaction logic for AddItemToStock.xaml
    /// </summary>
    public partial class AddItemToStock : Window
    {
        private MyWPFClient client;

        public AddItemToStock(MyWPFClient client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            const int ADD_ITEM_TO_STOCK = 2;
            RequestDTOBuilder requestDTOBuilder = new RequestDTOBuilder().WithCommand(ADD_ITEM_TO_STOCK).WithEmployeeId(client.selectedEmployee.ID);
            ItemDTOBuilder itemDTOBuilder = new ItemDTOBuilder();
            string errorMsg = "";

            // item name validation
            if (ItemName.Text == "")
            {
                errorMsg += "Please input item name\n";
            }

            // item quantity validation
            try
            {
                if (int.Parse(ItemQuantity.Text) < 0)
                {
                    errorMsg += "Please input an item quantity above 0\n";
                }
            }
            catch (Exception)
            {
                errorMsg += "Please input an item quantity\n";
            }

            // item price validation
            try
            {
                if (double.Parse(ItemPrice.Text) < 0)
                {
                    errorMsg += "Please input an item price above 0\n";
                }
            }
            catch (Exception)
            {
                errorMsg += "Please input an item price\n";
            }
            

            if (errorMsg.Length > 0)
            {
                MessageBox.Show(this, errorMsg, "Item not added", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ItemDTO item = itemDTOBuilder.WithName(ItemName.Text).WithQuantity(int.Parse(ItemQuantity.Text)).WithPrice(double.Parse(ItemPrice.Text)).Build();
                RequestDTO request = requestDTOBuilder.WithItem(item).Build();
                client.QueueRequest(request);
                MessageBox.Show(this, "Item added");
                this.Close();
            }
        }
    }
}
