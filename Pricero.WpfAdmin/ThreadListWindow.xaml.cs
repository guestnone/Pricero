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
using Section = Pricero.Core.Db.Section;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for ThreadListWindow.xaml
    /// </summary>
    public partial class ThreadListWindow : Window
    {
        public static DataGrid dataGrid;
        private int Id;
        public ThreadListWindow(int id)
        {
            InitializeComponent();
            Id = id;
            dataGrid = grid;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                grid.ItemsSource = db.ForumThreads.Where(m => m.Section.SectionID == id).ToList();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddForumThreadWindow(Id);
            window.ShowDialog();
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (grid.SelectedItem as ForumThread).ThreadID;
            var window = new UserPostListWindow(id);
            window.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (grid.SelectedItem as ForumThread).ThreadID;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.ForumThreads.Remove(db.ForumThreads.Where(m => m.ThreadID == id).Single());
                db.SaveChanges();
                grid.ItemsSource = db.ForumThreads.Where(m => m.Section.SectionID == id).ToList();
            }
        }
    }
}
