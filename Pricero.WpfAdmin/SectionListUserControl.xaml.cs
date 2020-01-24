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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Section = Pricero.Core.Db.Section;

namespace Pricero.WpfAdmin
{
    /// <summary>
    /// Interaction logic for UsersListUserControl.xaml
    /// </summary>
    public partial class SectionListUserControl : UserControl
    {
        public static DataGrid dataGrid;
        public SectionListUserControl()
        {
            InitializeComponent();
            dataGrid = grid;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                grid.ItemsSource = db.Sections.ToList();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddForumSectionWindow();
            window.ShowDialog();
        }

        public void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            int id = (grid.SelectedItem as Section).SectionID;
            using (PriceroDBContext db = new PriceroDBContext())
            {
                db.Sections.Remove(db.Sections.Where(m => m.SectionID == id).Single());
                db.SaveChanges();
                grid.ItemsSource = db.Sections.ToList();
            }

        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (grid.SelectedItem as Section).SectionID;
            var window = new ThreadListWindow(id);
            window.ShowDialog();
        }
    }
}
