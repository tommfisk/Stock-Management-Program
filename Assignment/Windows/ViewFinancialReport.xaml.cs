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
    /// Interaction logic for ViewFinancialReport.xaml
    /// </summary>
    public partial class ViewFinancialReport : Window
    {
        private MyWPFClient client;

        public ViewFinancialReport(MyWPFClient client)
        {
            InitializeComponent();
            this.client = client;
            financialReport();
        }

        private void financialReport()
        {
            RequestDTO request = new RequestDTOBuilder().WithCommand(5).Build();
            client.QueueRequest(request);

            while (FinancialReport.ItemsSource == null)
            {
                if (client.items != null)
                {
                    List<string> items = new List<string>();
                    double itemTotal = 0;
                    double total = 0;

                    client.items.ForEach(itemDTO =>
                    {
                        itemTotal = itemDTO.Price * itemDTO.Quantity;
                        items.Add($"{itemDTO.ID}. {itemDTO.Item_Name}: £{itemTotal} ");
                        total += itemTotal;
                    });

                    FinancialReport.ItemsSource = items;
                    totalLabel.Content = $"Total: £{total}";
                }
            }


            
        }
    }
}
