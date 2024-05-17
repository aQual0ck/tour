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
    /// Логика взаимодействия для PageEditClient.xaml
    /// </summary>
    public partial class PageEditClient : Page
    {
        private important.Clients c;
        public PageEditClient(object item)
        {
            InitializeComponent();
            DataContext = item;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            c.FirstName = txbFirstName.Text;
            c.LastName = txbLastName.Text;
            c.Tour_Id = Convert.ToInt32(txbTour.Text);
            c.PassportNumber = txbPassport.Text;
            c.VisaNumber = txbVisa.Text;
            c.InsuranceNumber = txbInsurance.Text;
            important.dbhelper.entObj.SaveChanges();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            important.frameapp.frmObj.Navigate(new PageClients());
        }
    }
}
