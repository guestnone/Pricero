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
    /// Interaction logic for ShopListUserControl.xaml
    /// </summary>
    public partial class ShopListUserControl : UserControl
    {
        public static DataGrid dataGrid;
        public ShopListUserControl()
        {
            InitializeComponent();
            dataGrid = grid;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                grid.ItemsSource = db.Shops.ToList();
            }
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddShopWindow();
            window.ShowDialog();
        }
        public void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            int id = (grid.SelectedItem as Shop).ShopId;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.Shops.Remove(db.Shops.Where(m => m.ShopId == id).Single());
                db.SaveChanges();
                grid.ItemsSource = db.Shops.ToList();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddChainWindow();
            window.ShowDialog();
        }
    }
}
