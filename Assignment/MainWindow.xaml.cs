﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment.Windows;
using DataGateway;

namespace Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public MainWindow()
        {
            InitializeComponent();
            dataGatewayFacade.InitialiseOracleDatabase();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddItemToStock_Click(object sender, RoutedEventArgs e)
        {
            AddItemToStock window = new AddItemToStock()
            {
                Owner = this
            };

            window.ShowDialog();
        }

        private void AddQuantityToItem_Click(object sender, RoutedEventArgs e)
        {
            AddQuantityToItem window = new AddQuantityToItem()
            {
                Owner = this
            };

            window.ShowDialog();
        }
    }
}