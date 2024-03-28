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
    /// Interaction logic for ViewPersonalUsageReport.xaml
    /// </summary>
    public partial class ViewPersonalUsageReport : Window
    {

        public ViewPersonalUsageReport()
        {
            InitializeComponent();
            bindDataGrid();  
        }

        private void bindDataGrid()
        {
            /*List<TransactionDTO> transactions = dataGatewayFacade.GetAllTransactions();
            List<TransactionDTO> personalTransactions = new List<TransactionDTO>();

            foreach (TransactionDTO transaction in transactions) 
            {  
                if (transaction.Employee_ID == 1)
                {
                    personalTransactions.Add(transaction);
                }
            }

            PersonalUsageDataGrid.ItemsSource = personalTransactions;*/
        }
    }
}
