﻿using Pricero.Core.Db;
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
        public bool isSave = false;
        public Product product = new Product();

        public AddProductWindow()
        {
            InitializeComponent();
            using (PriceroDBContext db = new PriceroDBContext())
            {
                groupComboBox.ItemsSource = db.ProductGroups.ToList();
                producerComboBox.ItemsSource = db.Producers.ToList();
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (groupComboBox.SelectedItem != null || producerComboBox.SelectedItem != null) {
                return;
            }

            isSave = true;
            product.ProductName = productName.Text;
            product.ProductWeight = Convert.ToDouble(productWeight.Text);
            product.UpcCode = productUps.Text;
            product.ProductGroup = (groupComboBox.SelectedItem as ProductGroup);
            product.Producer = (producerComboBox.SelectedItem as Producer);

            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
                ProductListUserControl.dataGrid.ItemsSource = db.Products.ToList();
            }
            this.Close();
        }
    }
}
