using DataGateway;
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
    /// Interaction logic for ViewTransactionLog.xaml
    /// </summary>
    public partial class ViewTransactionLog : Window
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public ViewTransactionLog()
        {
            InitializeComponent();
            bindDataGrid();
        }

        private void bindDataGrid()
        {
            TransactionDataGrid.ItemsSource = dataGatewayFacade.GetAllTransactions();
        }
    }
}
