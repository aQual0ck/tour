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
    /// Логика взаимодействия для PageAddTour.xaml
    /// </summary>
    public partial class PageAddTour : Page
    {
        private important.Tour t;
        public PageAddTour()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            important.frameapp.frmObj.Navigate(new PageAdmin());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            t = new important.Clients()
            {
                FirstName = txbFirstName.Text,
                LastName = txbLastName.Text,
                Tour_Id = (int)id,
                PassportNumber = txbPassport.Text,
                VisaNumber = txbVisa.Text,
                InsuranceNumber = txbInsurance.Text
            };
            important.dbhelper.entObj.Clients.Add(c);
            important.dbhelper.entObj.SaveChanges();
        }
    }
}
