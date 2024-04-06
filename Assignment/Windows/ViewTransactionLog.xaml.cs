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
    /// Interaction logic for ViewTransactionLog.xaml
    /// </summary>
    public partial class ViewTransactionLog : Window
    {
        private MyWPFClient client;

        public ViewTransactionLog(MyWPFClient client)
        {
            InitializeComponent();
            this.client = client;
            transactionLog();
        }

        private async void transactionLog()
        {
            RequestDTO request = new RequestDTOBuilder().WithCommand(6).Build();
            
            ResponseDTO response = await client.QueueRequest(request);

            TransactionDataGrid.ItemsSource = response.transactions;
        }
    }
}
