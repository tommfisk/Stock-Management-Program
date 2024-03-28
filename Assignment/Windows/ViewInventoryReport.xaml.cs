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
    /// Interaction logic for ViewInventoryReport.xaml
    /// </summary>
    public partial class ViewInventoryReport : Window
    {

        public ViewInventoryReport()
        {
            InitializeComponent();
            bindDataGrid();
        }

        private void bindDataGrid()
        {
            /*InventoryDataGrid.ItemsSource = dataGatewayFacade.GetAllItems();*/
        }

    }
}
