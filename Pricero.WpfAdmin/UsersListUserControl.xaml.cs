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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Pricero.WpfAdmin
{
    
    /// <summary>
    /// Interaction logic for UsersListUserControl.xaml
    /// </summary>
    public partial class UsersListUserControl : UserControl
    {
        private PriceroDBContext dbContext = null;

        public UsersListUserControl()
        {
            InitializeComponent();
            
        }

        public UsersListUserControl(PriceroDBContext context)
        {
            InitializeComponent();
            dbContext = context;
            dataGrid.ItemsSource = dbContext.Users.Local.ToObservableCollection();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUserWindow();
            window.ShowDialog();
            if (window.IsSave && dbContext != null)
            {
                dbContext.Add<User>(window.User);
                dbContext.SaveChanges();
                dataGrid.Items.Refresh();
            }
            window.Close();
        }
    }
}
