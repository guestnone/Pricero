using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
using BCrypt.Net;
using System.Linq;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public bool IsSave = false;
        public User User = new User();

        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            User.Email = textBoxEMail.Text;
            User.FirstName = textBoxFirstName.Text;
            User.LastName = textBoxLastName.Text;
            User.Nickname = textBoxNickname.Text;
            User.PasswordSalt = BCrypt.Net.BCrypt.GenerateSalt();
            User.PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordBox.Password, User.PasswordSalt);
            User.UserType = textBoxUserType.Text;

            using (PriceroDBContext db = new PriceroDBContext())
            {
                
                db.Users.Add(User);
                db.SaveChanges();
                UsersListUserControl.dataGrid.ItemsSource = db.Users.ToList();
            }

            this.Close();
        }
    }
}
