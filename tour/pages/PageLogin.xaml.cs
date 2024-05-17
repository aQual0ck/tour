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
using System.Windows.Threading;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace tour.pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(txbLogin.Text))
            {
                txbLogin.Text = "Введите логин";
                txbLogin.Foreground = Brushes.Gray;
                txbLogin.GotFocus += RemoveTextLogin;
                txbLogin.LostFocus += AddTextLogin;
            }

            if (string.IsNullOrEmpty(txbPassword.Text))
            {
                txbPassword.Text = "Введите пароль";
                txbPassword.Foreground = Brushes.Gray;
                txbPassword.GotFocus += RemoveTextPassword;
                txbPassword.LostFocus += AddTextPassword;
            }

            txbLogin.Focus();
        }
        private void RemoveTextLogin(object sender, EventArgs e)
        {
            if (txbLogin.Text == "Введите логин")
            {
                txbLogin.Text = "";
                txbLogin.Foreground = Brushes.Black;
            }
                
        }
        private void AddTextLogin(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbLogin.Text))
            {
                txbLogin.Text = "Введите логин";
                txbLogin.Foreground = Brushes.Gray;
            }
        }
        private void RemoveTextPassword(object sender, EventArgs e)
        {
            if (txbPassword.Text == "Введите пароль")
            {
                txbPassword.Text = "";
                txbPassword.Foreground = Brushes.Black;
            }
                
        }
        private void AddTextPassword(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbPassword.Text))
            {
                txbPassword.Text = "Введите пароль";
                txbPassword.Foreground = Brushes.Gray;
            }
        }
        //internal async Task HeavyMethodAsync(FontAwesome.WPF.ImageAwesome loadingSpinner)
        //{
        //    while (IsWorking)
        //    {
        //        loadingSpinner.Dispatcher.Invoke(() =>
        //        {
        //            loadingSpinner.Visibility = Visibility.Visible;
        //        });
        //    }
        //    await Task.Delay(2);
        //}
        //internal async Task LoadAsync()
        //{
        //    try
        //    {
        //        if (txbLogin.Text != "" && txbPassword.Text != "" && txbLogin.Text != "Введите логин" && txbPassword.Text != "Введите пароль")
        //        {
        //            var userObj = important.dbhelper.entObj.Users.FirstOrDefault(x => x.Name == txbLogin.Text && x.Password == txbPassword.Text);
        //            if (userObj == null)
        //            {
        //                tbWarning.Visibility = Visibility.Visible;
        //            }
        //            else if (userObj.Role_Id == 1)
        //            {
        //                important.frameapp.frmObj.Navigate(new PageAdmin());
        //            }
        //            else
        //            {
        //                important.frameapp.frmObj.Navigate(new PageUser());
        //            }
        //        }
        //        else
        //        {
        //            tbNoText.Visibility = Visibility.Visible;
        //            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
        //            timer.Start();
        //            timer.Tick += (sender1, args) =>
        //            {
        //                timer.Stop();
        //                tbNoText.Visibility = Visibility.Hidden;
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ошибка " + ex.Message.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //    await Task.Delay(2);
        //}
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            var worker = new BackgroundWorker();
            loadingSpinner.Dispatcher.Invoke(() =>
            {
                loadingSpinner.Visibility = Visibility.Visible;
            });
            try
            {
                if (txbLogin.Text != "" && txbPassword.Text != "" && txbLogin.Text != "Введите логин" && txbPassword.Text != "Введите пароль")
                {
                    var userObj = important.dbhelper.entObj.Users.FirstOrDefault(x => x.Name == txbLogin.Text && x.Password == txbPassword.Text);
                    if (userObj == null)
                    {
                        tbWarning.Dispatcher.Invoke(() => tbWarning.Visibility = Visibility.Visible);
                    }
                    else if (userObj.Role_Id == 1)
                    {
                        important.frameapp.frmObj.Navigate(new PageAdmin());
                    }
                    else
                    {
                        important.frameapp.frmObj.Navigate(new PageUser());
                    }
                }
                else
                {
                    tbNoText.Dispatcher.Invoke(() => tbNoText.Visibility = Visibility.Visible);
                    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
                    timer.Start();
                    timer.Tick += (sender1, args) =>
                    {
                        timer.Stop();
                        tbNoText.Dispatcher.Invoke(() => tbNoText.Visibility = Visibility.Hidden);
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
