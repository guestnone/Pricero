﻿using System;
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
        public UsersListUserControl()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUserWindow();
            window.ShowDialog();
            
            // TODO: Add db add
        }
    }
}