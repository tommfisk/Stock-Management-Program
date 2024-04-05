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
using WPF_Client;

namespace Assignment.Windows
{
    /// <summary>
    /// Interaction logic for ViewInventoryReport.xaml
    /// </summary>
    public partial class ViewInventoryReport : Window
    {
        private MyWPFClient client;

        public ViewInventoryReport(MyWPFClient client)
        {
            InitializeComponent();
            this.client = client;
            inventoryReport();
        }

        private void inventoryReport()
        {
            RequestDTO request = new RequestDTOBuilder().WithCommand(4).Build();
            client.QueueRequest(request);

            while (InventoryDataGrid.ItemsSource == null)
            {
                if (client.items != null)
                {
                    InventoryDataGrid.ItemsSource = client.items;
                }
            }
            
        }

    }
}
