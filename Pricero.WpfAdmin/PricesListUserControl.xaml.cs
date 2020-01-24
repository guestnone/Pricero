using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for UsersListUserControl.xaml
    /// </summary>
    public partial class PricesListUserControl : UserControl
    {
        public static DataGrid dataGrid;
        public PricesListUserControl()
        {
            InitializeComponent();
            dataGrid = grid;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                grid.ItemsSource = db.ChainProducts.Include("Product").Include("Chain").Include("Discount").ToList();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddChainProductWindow();
            window.ShowDialog();
        }

        public void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            int id = (grid.SelectedItem as ChainProduct).ChainProductID;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.ChainProducts.Remove(db.ChainProducts.Where(m => m.ChainProductID == id).Single());
                db.SaveChanges();
                grid.ItemsSource = db.ChainProducts.Include("Product").Include("Chain").Include("Discount").ToList();
            }

        }

        private void discountBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (grid.SelectedItem as ChainProduct).ChainProductID;
            var window = new AddDiscountWindow(id);
            window.ShowDialog();
        }

        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (grid.SelectedItem as ChainProduct).ChainProductID;
            var window = new AddReportWindow(id);
            window.ShowDialog();
        }
    }
}
