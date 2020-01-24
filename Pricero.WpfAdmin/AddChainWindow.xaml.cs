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
    /// Interaction logic for AddChainWindow.xaml
    /// </summary>
    public partial class AddChainWindow : Window
    {
        public Chain chain = new Chain();
        public AddChainWindow()
        {
            InitializeComponent();

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            chain.ChainName = textBox.Text;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.Chains.Add(chain);
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
