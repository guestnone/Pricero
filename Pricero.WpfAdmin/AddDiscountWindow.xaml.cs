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
using Microsoft.EntityFrameworkCore;
using Pricero.Core.Db;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for AddDiscountWindow.xaml
    /// </summary>
    public partial class AddDiscountWindow : Window
    {
        public Discount discount = new Discount();
        private int Id;

        public AddDiscountWindow(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            discount.DiscountPrice = Convert.ToDouble(textBox.Text);
            discount.DiscountFrom = (DateTime)dpFrom.SelectedDate;
            discount.DiscountTo = (DateTime)dpTo.SelectedDate;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                ChainProduct product = db.ChainProducts.Where(m => m.ChainProductID == Id).Single();
                discount.ChainProduct = product;
                db.Discounts.Add(discount);
                db.SaveChanges();
                PricesListUserControl.dataGrid.ItemsSource = db.ChainProducts.Include("Product").Include("Chain").Include("Discount").ToList();
            }
            this.Close();
        }
    }
}
