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
    /// Interaction logic for AddForumThreadWindow.xaml
    /// </summary>
    public partial class AddForumThreadWindow : Window
    {
        public bool Added = false;
        public ForumThread forumThread = new ForumThread();
        public AddForumThreadWindow()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            Added = true;
            forumThread.ThreadTitle = textBox.Text;
            forumThread.ThreadDate = (DateTime)dp.SelectedDate;

            this.Hide();
        }
    }
}
