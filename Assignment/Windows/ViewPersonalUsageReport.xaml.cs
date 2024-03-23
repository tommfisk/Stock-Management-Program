using DataGateway;
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
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private EmployeeDTO employee;

        public ViewPersonalUsageReport(EmployeeDTO employee)
        {
            InitializeComponent();
            this.employee = employee;
            bindDataGrid();
            
        }

        private void bindDataGrid()
        {
            List<TransactionDTO> transactions = dataGatewayFacade.GetAllTransactions();
            List<TransactionDTO> personalTransactions = new List<TransactionDTO>();

            foreach (TransactionDTO transaction in transactions) 
            {  
                if (transaction.Employee_ID == employee.ID)
                {
                    personalTransactions.Add(transaction);
                }
            }

            PersonalUsageDataGrid.ItemsSource = personalTransactions;
        }
    }
}
