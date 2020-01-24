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
    /// Interaction logic for AddForumPageWindow.xaml
    /// </summary>
    public partial class AddForumPageWindow : Window
    {
        public UserPost userPost = new UserPost();
        public int Id;
        public AddForumPageWindow(int id)
        {
            InitializeComponent();
            Id = id;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                userComboBox.ItemsSource = db.Users.ToList();
            }
            userComboBox.DisplayMemberPath = "Nickname";
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            userPost.PostContent = textBox.Text;
            userPost.PostDate = DateTime.Now;

            int userId = (userComboBox.SelectedItem as User).UserId;

            using (PriceroDBContext db = new PriceroDBContext())
            {
                userPost.User = db.Users.Where(m => m.UserId == userId).Single();
                db.UserPosts.Add(userPost);
                db.SaveChanges();
                UserPostListWindow.dataGrid.ItemsSource = db.UserPosts.Where(m => m.Thread.ThreadID == Id).ToList();
            }
            this.Close();
        }
    }
}
