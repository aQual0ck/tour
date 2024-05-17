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

namespace tour.pages
{
    /// <summary>
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        public PageUser()
        {
            InitializeComponent();
            dgrTours.ItemsSource = important.dbhelper.entObj.Tour.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = dgrTours.SelectedItem;
            important.frameapp.frmObj.Navigate(new PageAdd(item));
        }
    }
}
