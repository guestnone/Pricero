using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pricero.Core.Db;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for AddChainProductWindow.xaml
    /// </summary>
    public partial class AddChainProductWindow : Window
    {
        public bool IsCreate = false;
        public ChainProduct ChainProduct = new ChainProduct(); 
        public AddChainProductWindow()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {

            ChainProduct.Price = Convert.ToDouble(textBox.Text);

            this.Hide();
        }
    }
}
