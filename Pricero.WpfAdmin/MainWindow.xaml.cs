using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TabItem> TabItems { get; set; }

        public static RoutedUICommand ExitCommand = new RoutedUICommand("Exit",
            "ExitCommand",
            typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
            TabItems = new ObservableCollection<TabItem>
            {
                new TabItem{Content = new UsersListUserControl(), Header = "Users"},
                new TabItem{Content = new ProductListUserControl(), Header = "Products"},
                new TabItem{Content = new NotImplementedUserControl(), Header = "Prices"},
                new TabItem{Content = new ShopListUserControl(), Header = "Shops"}
            };

            TabControl.ItemsSource = TabItems;
        }

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButton.YesNo,
                    MessageBoxImage.Information) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}
