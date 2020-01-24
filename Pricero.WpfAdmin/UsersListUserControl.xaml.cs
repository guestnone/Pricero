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
            dataGrid = userDataGrid;
        }

        public void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUserWindow();
            window.ShowDialog();
        }

        public void updateProduct_Click(object sender, RoutedEventArgs e)
        {
            int id = (userDataGrid.SelectedItem as User).UserId;
            var window = new UpdateProductWindow(id);
            window.ShowDialog();
        }
    }

}
