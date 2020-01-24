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
    /// Interaction logic for AddForumThreadWindow.xaml
    /// </summary>
    public partial class AddForumThreadWindow : Window
    {
        public ForumThread forumThread = new ForumThread();
        public int Id;
        public AddForumThreadWindow(int id)
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
            forumThread.ThreadTitle = textBox.Text;
            forumThread.ThreadDate = DateTime.Now;

            using (PriceroDBContext db = new PriceroDBContext())
            {
                forumThread.Section = db.Sections.Where(m => m.SectionID == Id).Single();
                db.ForumThreads.Add(forumThread);
                db.SaveChanges();
                ThreadListWindow.dataGrid.ItemsSource = db.ForumThreads.Where(m => m.Section.SectionID == Id).ToList();
            }
            this.Close();
        }
    }
}
