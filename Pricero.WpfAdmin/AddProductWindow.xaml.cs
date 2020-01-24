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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public Product product = new Product();

        public AddProductWindow()
        {
            InitializeComponent();
            using (PriceroDBContext db = new PriceroDBContext())
            {
                groupComboBox.ItemsSource = db.ProductGroups.ToList();
                producerComboBox.ItemsSource = db.Producers.ToList();
            }
            groupComboBox.DisplayMemberPath = "ProductGroupID";
            producerComboBox.DisplayMemberPath = "ProducerName";
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            

            product.ProductName = productName.Text;
            product.ProductWeight = Convert.ToDouble(productWeight.Text);
            product.UpcCode = productUps.Text;
            string groupId = (groupComboBox.SelectedItem as ProductGroup).ProductGroupID;
            int producerId = (producerComboBox.SelectedItem as Producer).ProducerID;

            using (PriceroDBContext db = new PriceroDBContext())
            {
                product.Producer = db.Producers.Where(m => m.ProducerID == producerId).Single();
                product.ProductGroup = db.ProductGroups.Where(m => m.ProductGroupID == groupId).Single();
                db.Products.Add(product);
                db.SaveChanges();
                ProductListUserControl.dataGrid.ItemsSource = db.Products.ToList();
            }
            this.Close();
        }
    }
}
