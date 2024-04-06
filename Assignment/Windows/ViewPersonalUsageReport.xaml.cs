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
    /// Interaction logic for ViewPersonalUsageReport.xaml
    /// </summary>
    public partial class ViewPersonalUsageReport : Window
    {
        private MyWPFClient client;

        public ViewPersonalUsageReport(MyWPFClient client)
        {
            InitializeComponent();
            this.client = client;
            personalTransactionlLog();  
        }

        private async void personalTransactionlLog()
        {
            RequestDTO request = new RequestDTOBuilder().WithCommand(7).WithEmployeeId(client.selectedEmployee.ID).Build();
            ResponseDTO response = await client.QueueRequest(request);

            PersonalUsageDataGrid.ItemsSource = response.transactions;

        }
    }
}
