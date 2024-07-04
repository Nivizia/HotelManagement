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
        private readonly IBookReservationRepository _repo = new BookReservationRepository();
        private readonly Customer _customer;
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
                dg_BoRe = null;
            }
            else if (dg_BoRe.Visibility == Visibility.Collapsed)
            {
                var bookingReservations = _repo.GetBookingReservationsByCustomerId(_customer.CustomerId);
                dg_BoRe.ItemsSource = bookingReservations;
                dg_BoRe.Visibility = Visibility.Visible;
            }
        }

        private void bt_AccPro_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
