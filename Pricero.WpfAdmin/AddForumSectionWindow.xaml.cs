using Pricero.Core.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for AddForumSectionWindow.xaml
    /// </summary>
    public partial class AddForumSectionWindow : Window
    {
        public Section section = new Section();
        public AddForumSectionWindow()
        {
            InitializeComponent();
            using (PriceroDBContext db = new PriceroDBContext())
            {
                SectionListUserControl.dataGrid.ItemsSource = db.Sections.ToList();
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            section.SectionTitle = sectionText.Text;
            section.SectionDate = DateTime.Now;

            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.Sections.Add(section);
                db.SaveChanges();
                SectionListUserControl.dataGrid.ItemsSource = db.Sections.ToList();
            }
            this.Close();
        }
    }
}
