using Pricero.Core.Db;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Shop shop = new Shop();

        public AddShopWindow()
        {
            InitializeComponent();
            using (PriceroDBContext db = new PriceroDBContext())
            {
                chainComboBox.ItemsSource = db.Shops.ToList();
            }
            chainComboBox.DisplayMemberPath = "ChainName";
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            shop.Street = textBoxStreet.Text;
            shop.Number = textBoxNumber.Text;
            shop.PostalCode = textBoxPCode.Text;
            shop.City = textBoxCity.Text;
            shop.Country = textBoxCountry.Text;
            int chainId = (chainComboBox.SelectedItem as Chain).ChainId;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                shop.Chain = db.Chains.Where(m => m.ChainId == chainId).Single();
                db.Shops.Add(shop);
                db.SaveChanges();
                ShopListUserControl.dataGrid.ItemsSource = db.Shops.ToList();
            }
            this.Close();
        }
    }
}
