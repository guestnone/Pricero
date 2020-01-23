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
using System.Linq;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        public bool isSave = false;
        public int Id;

        public UpdateProductWindow(int id)
        {
            Id = id;
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (groupComboBox.SelectedItem != null || producerComboBox.SelectedItem != null)
            {
                return;
            }
            isSave = true;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                Product productDb = (from p in db.Products
                                     where p.ProductID == Id
                                     select p).Single();
                productDb.ProductName = productName.Text;
                productDb.ProductWeight = Convert.ToDouble(productWeight.Text);
                productDb.UpcCode = productUps.Text;
                db.SaveChanges();
                ProductListUserControl.dataGrid.ItemsSource = db.Products.ToList();
            }
            
            
            this.Hide();
        }
    }
}
