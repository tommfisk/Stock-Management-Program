﻿using Assignment.Command;
using DataGateway;
using DTO;
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

namespace Assignment.Windows
{
    /// <summary>
    /// Interaction logic for AddItemToStock.xaml
    /// </summary>
    public partial class AddItemToStock : Window
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private static readonly List<EmployeeDTO> employeeList = dataGatewayFacade.GetAllEmployees();

        public AddItemToStock()
        {
            InitializeComponent();
            bindListBox();
        }

        private void bindListBox()
        {
            List<string> employeeNames = new List<string>();

            foreach(EmployeeDTO employee in employeeList)
            {
                employeeNames.Add(employee.Employee_Name);
            }

            EmployeeList.ItemsSource = employeeNames;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";

            // employee selection validation
            if (EmployeeList.SelectedIndex == -1)
            {
                errorMsg += "Please select an employee\n";
            }

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
                dataGatewayFacade.AddItem(new ItemDTO(ItemName.Text, int.Parse(ItemQuantity.Text), double.Parse(ItemPrice.Text)));
                ItemDTO item = dataGatewayFacade.FindItemByName(ItemName.Text);
                EmployeeDTO employee = dataGatewayFacade.FindEmployeeByName(EmployeeList.SelectedItem.ToString());
                dataGatewayFacade.AddTransaction(new TransactionDTO("Item Added", item.ID, employee.ID, int.Parse(ItemQuantity.Text)));
                MessageBox.Show(this, "Item added");
                this.Close();
            }

            EmployeeList.SelectedIndex = -1;
            
        }
    }
}