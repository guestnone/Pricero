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
using System.Windows.Shapes;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for UserPostListWindow.xaml
    /// </summary>
    public partial class UserPostListWindow : Window
    {
        public static DataGrid dataGrid;
        private int Id;
        public UserPostListWindow(int id)
        {
            InitializeComponent();
            Id = id;
            dataGrid = grid;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                grid.ItemsSource = db.UserPosts.Where(m => m.Thread.ThreadID == Id).ToList();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddForumPageWindow(Id);
            window.ShowDialog();
        }

        

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (grid.SelectedItem as UserPost).PostID;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.UserPosts.Remove(db.UserPosts.Where(m => m.PostID == id).Single());
                db.SaveChanges();
                grid.ItemsSource = db.UserPosts.Where(m => m.Thread.ThreadID == Id).ToList();
            }
        }
    }
}
