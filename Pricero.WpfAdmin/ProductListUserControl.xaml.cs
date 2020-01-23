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
    /// Interaction logic for ProductListUserControl.xaml
    /// </summary>
    public partial class ProductListUserControl : UserControl
    {
        public static DataGrid dataGrid;
        public ProductListUserControl()
        {
            InitializeComponent();
            dataGrid = productDataGrid;
        }
        
        public void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddProductWindow();
            window.ShowDialog();
        }

        public void updateProduct_Click(object sender, RoutedEventArgs e)
        {
            int id = (productDataGrid.SelectedItem as Product).ProductID;
            var window = new UpdateProductWindow(id);
            window.ShowDialog();
        }

        public void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            int id = (productDataGrid.SelectedItem as Product).ProductID;
            using (PriceroDBContext db = new PriceroDBContext()) {
                db.Products.Remove(db.Products.Where(m => m.ProductID == id).Single());
                db.SaveChanges();
                productDataGrid.ItemsSource = db.Products.ToList();
            }
                var window = new AddProductWindow();
            window.ShowDialog();
        }
    }
}
