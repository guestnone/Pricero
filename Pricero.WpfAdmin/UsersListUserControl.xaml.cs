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
    /// Interaction logic for UsersListUserControl.xaml
    /// </summary>
    public partial class UsersListUserControl : UserControl
    {
        public static DataGrid dataGrid;
        public UsersListUserControl()
        {
            InitializeComponent();
            dataGrid = grid;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                grid.ItemsSource = db.Users.ToList();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUserWindow();
            window.ShowDialog();
        }

        public void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            int id = (grid.SelectedItem as User).UserId;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.Users.Remove(db.Users.Where(m => m.UserId == id).Single());
                db.SaveChanges();
                grid.ItemsSource = db.Products.ToList();
            }

        }
    }
}
