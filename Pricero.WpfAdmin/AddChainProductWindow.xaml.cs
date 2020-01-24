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
using Pricero.Core.Db;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for AddChainProductWindow.xaml
    /// </summary>
    public partial class AddChainProductWindow : Window
    {
        public bool IsCreate = false;
        public ChainProduct chainProduct = new ChainProduct(); 
        public AddChainProductWindow()
        {
            InitializeComponent();
            using (PriceroDBContext db = new PriceroDBContext())
            {
                comboBoxChain.ItemsSource = db.Chains.ToList();
                comboBoxProduct.ItemsSource = db.Products.ToList();
            }
            comboBoxChain.DisplayMemberPath = "ChainName";
            comboBoxProduct.DisplayMemberPath = "ProductName";
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {

            chainProduct.Price = Convert.ToDouble(textBox.Text);

            int productId = (comboBoxProduct.SelectedItem as Product).ProductID;
            int chainId = (comboBoxChain.SelectedItem as Chain).ChainId;

            using (PriceroDBContext db = new PriceroDBContext())
            {
                chainProduct.Product = db.Products.Where(m => m.ProductID == productId).Single();
                chainProduct.Chain = db.Chains.Where(m => m.ChainId == chainId).Single();
                db.ChainProducts.Add(chainProduct);
                db.SaveChanges();
                PricesListUserControl.dataGrid.ItemsSource = db.ChainProducts.ToList();
            }

            this.Hide();
        }
    }
}
