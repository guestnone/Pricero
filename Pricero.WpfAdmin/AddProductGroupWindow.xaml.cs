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
    /// Interaction logic for AddProducerWindow.xaml
    /// </summary>
    public partial class AddProductGroupWindow : Window
    {
        public ProductGroup productGroup = new ProductGroup();
        public AddProductGroupWindow()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {

            productGroup.ProductGroupID = productGroupId.Text;
            productGroup.BaseVATCharge = Convert.ToDouble(baseVatCharge.Text);
            

            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.ProductGroups.Add(productGroup);
                db.SaveChanges();
                
            }
            this.Close();
        }
    }
}
