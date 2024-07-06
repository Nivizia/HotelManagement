using BusinessObjects.Models;
using DAOs.DTOs;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private readonly ICustomerRepository _repo = new CustomerRepository();
        private readonly IRoomInformationRepository _roomInfoRepo = new RoomInformationRepository();
        private readonly IRoomTypeRepository _roomTypeRepo = new RoomTypeRepository();
        private readonly IBookReservationRepository _bookReservationRepo = new BookReservationRepository();
        private readonly IBookingDetailRepository _bookingDetailRepo = new BookingDetailRepository();

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void bt_Customers_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            var customers = _repo.GetCustomers();
            lv_CusList.ItemsSource = customers;
            sp_CusList.Visibility = Visibility.Visible;
        }

        private void bt_CusDetails_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            sp_CusTitle.Visibility = Visibility.Visible;
            sp_CusPlaceholder.Visibility = Visibility.Visible;

            var button = sender as Button;
            if (button != null)
            {
                var customer = button.DataContext as Customer;
                if (customer != null)
                {
                    PH_CustomerID.Content = customer.CustomerId;
                    PH_Fullname.Content = customer.CustomerFullName;
                    PH_Telephone.Content = customer.Telephone;
                    PH_Email.Content = customer.EmailAddress;
                    PH_Birthday.Content = customer.CustomerBirthday;
                    PH_Status.Content = customer.CustomerStatus;
                    PH_Password.Content = customer.Password;
                }
            }
        }

        private void bt_CusUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (sp_CusUpdate.Visibility == Visibility.Visible)
            {
                sp_CusUpdate.Visibility = Visibility.Collapsed;
                sp_CusPlaceholder.Visibility = Visibility.Visible;
            }
            else if (sp_CusUpdate.Visibility == Visibility.Collapsed)
            {
                sp_CusUpdate.Visibility = Visibility.Visible;
                sp_CusPlaceholder.Visibility = Visibility.Collapsed;
                lbl_CustomerID.Content = PH_CustomerID.Content;
                txtb_Fullname.Text = PH_Fullname.Content.ToString();
                txtb_Telephone.Text = PH_Telephone.Content.ToString();
                txtb_Email.Text = PH_Email.Content.ToString();
                txtb_Birthday.Text = PH_Birthday.Content.ToString();
                txtb_Status.Text = PH_Status.Content.ToString();
                txtb_Password.Text = PH_Password.Content.ToString();
            }
        }

        private void bt_Logout_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void bt_CusConfirm_Click(object sender, RoutedEventArgs e)
        {
            var Customer = new Customer
            {
                CustomerId = Convert.ToInt32(lbl_CustomerID.Content),
                CustomerFullName = txtb_Fullname.Text,
                Telephone = txtb_Telephone.Text,
                EmailAddress = txtb_Email.Text,
                CustomerBirthday = DateOnly.FromDateTime(Convert.ToDateTime(txtb_Birthday.Text)),
                CustomerStatus = Convert.ToByte(txtb_Status.Text),
                Password = txtb_Password.Text
            };

            if (_repo.UpdateCustomer(Customer))
            {
                MessageBox.Show("Update successfully!");
                PH_Fullname.Content = Customer.CustomerFullName;
                PH_Telephone.Content = Customer.Telephone;
                PH_Email.Content = Customer.EmailAddress;
                PH_Birthday.Content = Customer.CustomerBirthday;
                PH_Status.Content = Customer.CustomerStatus;
                PH_Password.Content = Customer.Password;
                sp_CusUpdate.Visibility = Visibility.Collapsed;
                sp_CusPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Update failed!");
            }
        }

        private void bt_CusDelete_Click(object sender, RoutedEventArgs e)
        {
            var CusID = TT_CustomerID.Content;
            if (_repo.DeleteCus(Convert.ToInt32(CusID)))
            {
                MessageBox.Show("Delete successfully!");
                sp_CusTitle.Visibility = Visibility.Collapsed;
                sp_CusPlaceholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Delete failed!");
            }
        }

        private void bt_Rooms_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            sp_FcRoomInfo.Visibility = Visibility.Visible;
        }

        private void bt_RoomInformation_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            var roominfos = _roomInfoRepo.GetAll();
            lv_RoomList.ItemsSource = roominfos;
            sp_RoomList.Visibility = Visibility.Visible;
        }

        private void bt_RoomDetails_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            sp_RoomTitle.Visibility = Visibility.Visible;
            sp_RoomPlaceholder.Visibility = Visibility.Visible;
            var button = sender as Button;
            if (button != null)
            {
                var roominfo = button.DataContext as RoomInfoDTO;
                if (roominfo != null)
                {
                    PH_RoomID.Content = roominfo.RoomId;
                    PH_RoomNumber.Content = roominfo.RoomNumber;
                    PH_RoomDetailDescription.Content = roominfo.RoomDetailDescription;
                    PH_RoomMaxCapacity.Content = roominfo.RoomMaxCapacity;
                    PH_RoomType.Content = roominfo.RoomType;
                    PH_RoomStatus.Content = roominfo.RoomStatus;
                    PH_RoomPricePerDay.Content = roominfo.RoomPricePerDay;
                }
            }
        }

        private void bt_RoomUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (sp_RoomUpdate.Visibility == Visibility.Visible)
            {
                sp_RoomUpdate.Visibility = Visibility.Collapsed;
                sp_RoomPlaceholder.Visibility = Visibility.Visible;
            }
            else if (sp_RoomUpdate.Visibility == Visibility.Collapsed)
            {
                sp_RoomUpdate.Visibility = Visibility.Visible;
                sp_RoomPlaceholder.Visibility = Visibility.Collapsed;
                lbl_RoomID.Content = PH_RoomID.Content;
                txtb_RoomNumber.Text = PH_RoomNumber.Content.ToString();
                txtb_RoomDetailDescription.Text = PH_RoomDetailDescription.Content.ToString();
                txtb_RoomMaxCapacity.Text = PH_RoomMaxCapacity.Content.ToString();
                txtb_RoomType.Text = PH_RoomType.Content.ToString();
                txtb_RoomStatus.Text = PH_RoomStatus.Content.ToString();
                txtb_RoomPricePerDay.Text = PH_RoomPricePerDay.Content.ToString();
            }
        }

        private void bt_RoomConfirm_Click(object sender, RoutedEventArgs e)
        {
            var roominfoDTO = new RoomInfoDTO
            {
                RoomId = Convert.ToInt32(lbl_RoomID.Content),
                RoomNumber = txtb_RoomNumber.Text,
                RoomDetailDescription = txtb_RoomDetailDescription.Text,
                RoomMaxCapacity = Convert.ToInt32(txtb_RoomMaxCapacity.Text),
                RoomType = txtb_RoomType.Text,
                RoomStatus = Convert.ToByte(txtb_RoomStatus.Text),
                RoomPricePerDay = Convert.ToDecimal(txtb_RoomPricePerDay.Text)
            };

            if (_roomInfoRepo.UpdateRoomInfo(roominfoDTO))
            {
                MessageBox.Show("Update successfully!");
                PH_RoomNumber.Content = roominfoDTO.RoomNumber;
                PH_RoomDetailDescription.Content = roominfoDTO.RoomDetailDescription;
                PH_RoomMaxCapacity.Content = roominfoDTO.RoomMaxCapacity;
                PH_RoomType.Content = roominfoDTO.RoomType;
                PH_RoomStatus.Content = roominfoDTO.RoomStatus;
                PH_RoomPricePerDay.Content = roominfoDTO.RoomPricePerDay;
                sp_RoomUpdate.Visibility = Visibility.Collapsed;
                sp_RoomPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Update failed!");
            }
        }

        private void bt_RoomDelete_Click(object sender, RoutedEventArgs e)
        {
            var RoomID = TT_RoomID.Content;
            if (_roomInfoRepo.DeleteRoomInfo(Convert.ToInt32(RoomID)))
            {
                MessageBox.Show("Delete successfully!");
                sp_RoomTitle.Visibility = Visibility.Collapsed;
                sp_RoomPlaceholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Delete failed!");
            }
        }

        private void bt_RoomTypeDetails_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            sp_RoomTypeTitle.Visibility = Visibility.Visible;
            sp_RoomTypePlaceholder.Visibility = Visibility.Visible;
            var button = sender as Button;
            if (button != null)
            {
                var roomType = button.DataContext as RoomType;
                if (roomType != null)
                {
                    PH_RoomTypeID.Content = roomType.RoomTypeId;
                    PH_RoomTypeName.Content = roomType.RoomTypeName;
                    PH_TypeDescription.Content = roomType.TypeDescription;
                    PH_TypeNote.Content = roomType.TypeNote;
                }
            }
        }

        private void bt_RoomTypeUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (sp_RoomTypeUpdate.Visibility == Visibility.Visible)
            {
                sp_RoomTypeUpdate.Visibility = Visibility.Collapsed;
                sp_RoomTypePlaceholder.Visibility = Visibility.Visible;
            }
            else if (sp_RoomTypeUpdate.Visibility == Visibility.Collapsed)
            {
                sp_RoomTypeUpdate.Visibility = Visibility.Visible;
                sp_RoomTypePlaceholder.Visibility = Visibility.Collapsed;
                lbl_RoomTypeID.Content = PH_RoomTypeID.Content;
                txtb_RoomTypeName.Text = PH_RoomTypeName.Content.ToString();
                txtb_TypeDescription.Text = PH_TypeDescription.Content.ToString();
                txtb_TypeNote.Text = PH_TypeNote.Content.ToString();
            }
        }

        private void bt_RoomTypeConfirm_Click(object sender, RoutedEventArgs e)
        {
            var roomType = new RoomType
            {
                RoomTypeId = Convert.ToInt32(lbl_RoomTypeID.Content),
                RoomTypeName = txtb_RoomTypeName.Text,
                TypeDescription = txtb_TypeDescription.Text,
                TypeNote = txtb_TypeNote.Text
            };

            if (_roomTypeRepo.UpdateRoomTypes(roomType))
            {
                MessageBox.Show("Update successfully!");
                PH_RoomTypeName.Content = roomType.RoomTypeName;
                PH_TypeDescription.Content = roomType.TypeDescription;
                PH_TypeNote.Content = roomType.TypeNote;
                sp_RoomTypeUpdate.Visibility = Visibility.Collapsed;
                sp_RoomTypePlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Update failed!");
            }
        }

        private void bt_RoomTypeDelete_Click(object sender, RoutedEventArgs e)
        {
            var roomTypeId = TT_RoomTypeID.Content;
            if (_roomTypeRepo.DeleteRoomType(Convert.ToInt32(roomTypeId)))
            {
                MessageBox.Show("Delete successfully!");
                sp_RoomTypeTitle.Visibility = Visibility.Collapsed;
                sp_RoomTypePlaceholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Delete failed!");
            }
        }

        private void bt_RoomType_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            var roomtypes = _roomTypeRepo.GetRoomTypes();
            lv_RoomTypeList.ItemsSource = roomtypes;
            sp_RoomTypeList.Visibility = Visibility.Visible;
        }

        private void HideAllPanels()
        {
            sp_CusList.Visibility = Visibility.Collapsed;
            sp_CusTitle.Visibility = Visibility.Collapsed;
            sp_CusPlaceholder.Visibility = Visibility.Collapsed;
            sp_CusUpdate.Visibility = Visibility.Collapsed;
            sp_RoomList.Visibility = Visibility.Collapsed;
            sp_RoomTitle.Visibility = Visibility.Collapsed;
            sp_RoomPlaceholder.Visibility = Visibility.Collapsed;
            sp_RoomUpdate.Visibility = Visibility.Collapsed;
            sp_RoomTypeList.Visibility = Visibility.Collapsed;
            sp_RoomTypeTitle.Visibility = Visibility.Collapsed;
            sp_RoomTypePlaceholder.Visibility = Visibility.Collapsed;
            sp_RoomTypeUpdate.Visibility = Visibility.Collapsed;
            sp_FcRoomInfo.Visibility = Visibility.Collapsed;
        }

        private void bt_Reservations_Click(object sender, RoutedEventArgs e)
        {
            sp_Reservations.Visibility = Visibility.Visible;
        }

        private void bt_BookingReservation_Click(object sender, RoutedEventArgs e)
        {
            sp_BookingReservationList.Visibility = Visibility.Visible;
            var bookingReservations = _bookReservationRepo.GetBookingReservations();
            lv_BookingReservationList.ItemsSource = bookingReservations;
        }

        private void bt_BookingReservationDetails_Click(object sender, RoutedEventArgs e)
        {
            sp_BookingReservationList.Visibility = Visibility.Collapsed;
            sp_BookingDetailList.Visibility = Visibility.Visible;
            var button = sender as Button;
            if (button != null)
            {
                var bookingReservation = button.DataContext as BookDetailDTO;
                if (bookingReservation != null)
                {
                    var bookingDetails = _bookingDetailRepo.GetBookingDetailsByBookingId(bookingReservation.BookingReservationId);
                    lv_BookingDetailList.ItemsSource = bookingDetails;
                }
            }
        }

        private void bt_BookingDetailReturn_Click(object sender, RoutedEventArgs e)
        {
            sp_BookingDetailList.Visibility = Visibility.Collapsed;
            sp_BookingReservationList.Visibility = Visibility.Visible;
            var bookingReservations = _bookReservationRepo.GetBookingReservations();
            lv_BookingReservationList.ItemsSource = bookingReservations;
        }
    }
}
