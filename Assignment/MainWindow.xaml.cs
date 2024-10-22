﻿using System.Windows;
using Assignment.Windows;
using WPF_Client;
using DTO;

namespace Assignment
{

    public partial class MainWindow : Window
    {
        private MyWPFClient client;


        public MainWindow()
        {
            InitializeComponent();
            client = new MyWPFClient();
            bindEmployeeList();
        }

        private async void bindEmployeeList()
        {
            RequestDTO request = new RequestDTOBuilder().WithCommand(8).Build();

            ResponseDTO response = await client.QueueRequest(request);

            List<string> employeeNames = new List<string>();

            foreach (EmployeeDTO employee in response.employees)
            {
                employeeNames.Add(employee.Employee_Name);
            }

            client.employees = response.employees;
            EmployeeList.ItemsSource = employeeNames;

        }

        private bool employeeIsSelected()
        {
            if (EmployeeList.SelectedIndex == -1)
            {
                return false;
            }

            foreach (EmployeeDTO employee in client.employees)
            {
                if (employee.Employee_Name == EmployeeList.SelectedItem)
                {
                    client.selectedEmployee = employee;
                }
            }

            return true;
        }

        private void display(Window window)
        {
            if (employeeIsSelected())
            {
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Please select an employee");
            }
        }

        private void AddItemToStock_Click(object sender, RoutedEventArgs e)
        {
            AddItemToStock window = new AddItemToStock(client)
            {
                Owner = this
            };

            display(window);
        }

        private void AddQuantityToItem_Click(object sender, RoutedEventArgs e)
        {
            AddQuantityToItem window = new AddQuantityToItem(client)
            {
                Owner = this
            };

            display(window);
        }

        private void TakeQuantityFromItem_Click(object sender, RoutedEventArgs e)
        {
            TakeQuantityFromItem window = new TakeQuantityFromItem(client)
            {
                Owner = this
            };

            display(window);
        }

        private void ViewInventoryReport_Click(object sender, RoutedEventArgs e)
        {
            ViewInventoryReport window = new ViewInventoryReport(client)
            {
                Owner = this
            };

            display(window);
        }

        private void FinancialReport_Click(object sender, RoutedEventArgs e)
        {
            ViewFinancialReport window = new ViewFinancialReport(client)
            {
                Owner = this
            };

            display(window);
        }

        private void TransactionLog_Click(object sender, RoutedEventArgs e)
        {
            ViewTransactionLog window = new ViewTransactionLog(client)
            {
                Owner = this
            };

            display(window);
        }

        private void PersonalUsageReport_Click(object sender, RoutedEventArgs e)
        {
            if (employeeIsSelected())
            {
                ViewPersonalUsageReport window = new ViewPersonalUsageReport(client)
                {
                    Owner = this
                };

                window.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Please select an employee");
            }
        }
    }
}