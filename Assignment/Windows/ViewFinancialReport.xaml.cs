﻿using DataGateway;
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
    /// Interaction logic for ViewFinancialReport.xaml
    /// </summary>
    public partial class ViewFinancialReport : Window
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public ViewFinancialReport()
        {
            InitializeComponent();
            financialReport();
        }

        private void financialReport()
        {
            List<ItemDTO> itemDTOs = dataGatewayFacade.GetAllItems();
            List<string> items = new List<string>();
            double itemTotal = 0;
            double total = 0;
            itemDTOs.ForEach(itemDTO => 
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