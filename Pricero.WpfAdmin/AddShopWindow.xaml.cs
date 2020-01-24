using Pricero.Core.Db;
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

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for AddShopWindow.xaml
    /// </summary>
    public partial class AddShopWindow : Window
    {
        public bool isSave = false;
        public Shop shop = new Shop();

        public AddShopWindow()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            isSave = true;
            shop.Street = textBoxStreet.Text;
            shop.Number = textBoxNumber.Text;
            shop.PostalCode = textBoxPCode.Text;
            shop.City = textBoxCity.Text;
            shop.Country = textBoxCountry.Text;
            this.Hide();
        }
    }
}
