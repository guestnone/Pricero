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
using Pricero.Core.Db;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for AddDiscountWindow.xaml
    /// </summary>
    public partial class AddDiscountWindow : Window
    {
        public bool Added = false;
        public Discount discount = new Discount();

        public AddDiscountWindow()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            Added = true;
            discount.DiscountPrice = Convert.ToDouble(textBox.Text);
            discount.DiscountFrom = (DateTime)dpFrom.SelectedDate;
            discount.DiscountTo = (DateTime)dpTo.SelectedDate;
            this.Hide();
        }
    }
}
