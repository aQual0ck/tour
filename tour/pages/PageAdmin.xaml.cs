using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace tour.pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        private important.Tour t;
        public PageAdmin()
        {
            InitializeComponent();
            dgrTours.ItemsSource = important.dbhelper.entObj.Tour.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = dgrTours.SelectedItem;
            important.frameapp.frmObj.Navigate(new PageEdit(item));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(dgrTours.SelectedItem)["Id"].GetValue(dgrTours.SelectedItem);
            t = important.dbhelper.entObj.Tour.FirstOrDefault(x => x.Id == (int)id);
            MessageBoxResult result = MessageBox.Show("Вы уверены?");
            if(result == MessageBoxResult.OK)
            {
                important.dbhelper.entObj.Tour.Remove(t);
                important.dbhelper.entObj.SaveChanges();
                dgrTours.ItemsSource = important.dbhelper.entObj.Tour.ToList();
            }
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            important.frameapp.frmObj.Navigate(new PageClients());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var item = dgrTours.SelectedItem;
            important.frameapp.frmObj.Navigate(new PageAdd(item));
        }

        private void btnAddTour_Click(object sender, RoutedEventArgs e)
        {
            important.frameapp.frmObj.Navigate(new PageAddTour());
        }
    }
}
