﻿using Repositories;
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
        public CustomerInterface()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBookingReservations();
        }

        public void LoadBookingReservations()
        {
            dg_BoRe.ItemsSource = _repo.GetBookingReservations();
        }

        private void bt_BoHi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_AccPro_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
