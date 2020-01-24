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
using Pricero.Core.Db;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for AddDiscountWindow.xaml
    /// </summary>
    public partial class AddReportWindow : Window
    {
        public PriceReport priceReport = new PriceReport();
        private int Id;

        public AddReportWindow(int id)
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
            priceReport.ReportContent = report.Text;
            
            using (PriceroDBContext db = new PriceroDBContext())
            {
                ChainProduct product = db.ChainProducts.Where(m => m.ChainProductID == Id).Single();
                priceReport.ChainProduct = product;
                db.PriceReports.Add(priceReport);
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
