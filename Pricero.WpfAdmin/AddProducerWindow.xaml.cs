﻿using Pricero.Core.Db;
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

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for AddProducerWindow.xaml
    /// </summary>
    public partial class AddProducerWindow : Window
    {
        public Producer producer = new Producer();
        public AddProducerWindow()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            
            producer.ProducerName = producerName.Text;
            producer.ProducerCountry = producerCountry.Text;
            producer.ProducerNIP = producerNIP.Text;
            

            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.Producers.Add(producer);
                db.SaveChanges();
                
            }
            this.Close();
        }
    }
}
