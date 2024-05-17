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
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        private important.Tour t;
        private important.TourType tt;
        private important.HotelType ht;
        public PageEdit(object item)
        {
            InitializeComponent();
            DataContext = item;
            var id = TypeDescriptor.GetProperties(DataContext)["Id"].GetValue(DataContext);
            var tourtype = TypeDescriptor.GetProperties(DataContext)["TourType"].GetValue(DataContext);
            var tourname = TypeDescriptor.GetProperties(tourtype)["TourTypeName"].GetValue(tourtype);
            var hoteltype = TypeDescriptor.GetProperties(DataContext)["HotelType"].GetValue(DataContext);
            var hotelname = TypeDescriptor.GetProperties(hoteltype)["HotelTypeName"].GetValue(hoteltype);
            t = important.dbhelper.entObj.Tour.FirstOrDefault(x => x.Id == (int)id);
            tt = important.dbhelper.entObj.TourType.FirstOrDefault(x => x.TourTypeName == (string)tourname);
            ht = important.dbhelper.entObj.HotelType.FirstOrDefault(x => x.HotelTypeName == (string)hotelname);

            cmbTourType.SelectedValuePath = "TourTypeName";
            cmbTourType.DisplayMemberPath = "TourTypeName";
            cmbTourType.ItemsSource = important.dbhelper.entObj.TourType.ToList();
            cmbTourType.SelectedValue = tt.TourTypeName;

            cmbHotelType.SelectedValuePath = "HotelTypeName";
            cmbHotelType.DisplayMemberPath = "HotelTypeName";
            cmbHotelType.ItemsSource = important.dbhelper.entObj.HotelType.ToList();
            cmbHotelType.SelectedValue = ht.HotelTypeName;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            important.frameapp.frmObj.Navigate(new PageAdmin());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var tourid = TypeDescriptor.GetProperties(cmbTourType.SelectionBoxItem)["Id"].GetValue(cmbTourType.SelectionBoxItem);
            var hotelid = TypeDescriptor.GetProperties(cmbHotelType.SelectionBoxItem)["Id"].GetValue(cmbHotelType.SelectionBoxItem);
            t.Country = txbCountry.Text;
            t.City = txbCity.Text;
            t.TourType_Id = (int)tourid;
            t.HotelType_Id = (int)hotelid;
            t.Food = txbFood.Text;
            t.DateStart = Convert.ToDateTime(txbDateStart.SelectedDate);
            t.DateEnd = Convert.ToDateTime(txbDateEnd.SelectedDate);
            t.Transport = txbTransport.Text;
            t.Price = Convert.ToInt32(txbPrice.Text);
            important.dbhelper.entObj.SaveChanges();
        }
    }
}
