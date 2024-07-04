using BusinessObjects.Models;
using Repositories;
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
using System.Windows.Shapes;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for CustomerInterface.xaml
    /// </summary>
    public partial class CustomerInterface : Window
    {
        private readonly IBookReservationRepository _BookReserRepo = new BookReservationRepository();
        private readonly ICustomerRepository _CustomerRepo = new CustomerRepository();
        private Customer _customer;
        public CustomerInterface(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBookingReservations();
        }

        public void LoadBookingReservations()
        {
        }

        private void bt_BoHi_Click(object sender, RoutedEventArgs e)
        {
            if (dg_BoRe.Visibility == Visibility.Visible)
            {
                dg_BoRe.Visibility = Visibility.Collapsed;
            }
            else if (dg_BoRe.Visibility == Visibility.Collapsed)
            {
                var bookingReservations = _BookReserRepo.GetBookingReservationsByCustomerId(_customer.CustomerId);
                dg_BoRe.ItemsSource = bookingReservations;
                dg_BoRe.Visibility = Visibility.Visible;
                Title.Visibility = Visibility.Collapsed;
                Placeholder.Visibility = Visibility.Collapsed;
                Update.Visibility = Visibility.Collapsed;
            }
        }

        private void bt_AccPro_Click(object sender, RoutedEventArgs e)
        {
            if (Title.Visibility == Visibility.Visible || Placeholder.Visibility == Visibility.Visible)
            {
                Title.Visibility = Visibility.Collapsed;
                Placeholder.Visibility = Visibility.Collapsed;
                Update.Visibility = Visibility.Collapsed;
            }
            else if (Title.Visibility == Visibility.Collapsed || Placeholder.Visibility == Visibility.Collapsed)
            {
                dg_BoRe.Visibility = Visibility.Collapsed;
                Title.Visibility = Visibility.Visible;
                Placeholder.Visibility = Visibility.Visible;
                PH_Fullname.Content = _customer.CustomerFullName;
                PH_Telephone.Content = _customer.Telephone;
                PH_Email.Content = _customer.EmailAddress;
                PH_Birthday.Content = _customer.CustomerBirthday;
                PH_Password.Content = _customer.Password;
            }
        }

        private void bt_Confirm_Click(object sender, RoutedEventArgs e)
        {
            var Customer = new Customer
            {
                CustomerId = _customer.CustomerId,
                CustomerFullName = txtb_Fullname.Text,
                Telephone = txtb_Telephone.Text,
                EmailAddress = txtb_Email.Text,
                CustomerBirthday = DateOnly.FromDateTime(Convert.ToDateTime(txtb_Birthday.Text)),
                Password = txtb_Password.Text
            };
            if (_CustomerRepo.UpdateCustomer(Customer))
            {
                MessageBox.Show("Update successfully!");
                _customer.CustomerFullName = Customer.CustomerFullName;
                _customer.Telephone = Customer.Telephone;
                _customer.EmailAddress = Customer.EmailAddress;
                _customer.CustomerBirthday = Customer.CustomerBirthday;
                _customer.Password = Customer.Password;
                Update.Visibility = Visibility.Collapsed;
                Placeholder.Visibility = Visibility.Visible;
                _customer = Customer;
            }
            else
            {
                MessageBox.Show("Update failed!");
            }
        }

        private void bt_Update_Click(object sender, RoutedEventArgs e)
        {
            if (Update.Visibility == Visibility.Visible)
            {
                Update.Visibility = Visibility.Collapsed;
                Placeholder.Visibility = Visibility.Visible;
            }
            else if (Update.Visibility == Visibility.Collapsed)
            {
                Update.Visibility = Visibility.Visible;
                Placeholder.Visibility = Visibility.Collapsed;
                txtb_Fullname.Text = _customer.CustomerFullName;
                txtb_Telephone.Text = _customer.Telephone;
                txtb_Email.Text = _customer.EmailAddress;
                txtb_Birthday.Text = _customer.CustomerBirthday.ToString();
                txtb_Password.Text = _customer.Password;
            }
        }

        private void Update_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PH_Fullname.Content = _customer.CustomerFullName;
            PH_Telephone.Content = _customer.Telephone;
            PH_Email.Content = _customer.EmailAddress;
            PH_Birthday.Content = _customer.CustomerBirthday;
            PH_Password.Content = _customer.Password;
        }

        private void bt_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
