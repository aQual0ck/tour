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
    /// Логика взаимодействия для PageClients.xaml
    /// </summary>
    public partial class PageClients : Page
    {
        private important.Clients c;
        public PageClients()
        {
            InitializeComponent();
            dgrClients.ItemsSource = important.dbhelper.entObj.Clients.ToList();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = dgrClients.SelectedItem;
            important.frameapp.frmObj.Navigate(new PageEditClient());
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(dgrClients.SelectedItem)["Id"].GetValue(dgrClients.SelectedItem);
            c = important.dbhelper.entObj.Clients.FirstOrDefault(x => x.Id == (int)id);
            MessageBoxResult result = MessageBox.Show("Вы уверены?");
            if(result == MessageBoxResult.OK)
            {
  
            }
        }
    }
}
