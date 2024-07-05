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
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Window
    {
        public Management()
        {
            InitializeComponent();
        }

        private void Button_Click_Customer(object sender, RoutedEventArgs e)
        {
            Admin_Customer manaCus = new Admin_Customer();
            manaCus.Show();
            this.Close();
        }

        private void Button_Click_Room(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Booking(object sender, RoutedEventArgs e)
        {

        }
    }
}
