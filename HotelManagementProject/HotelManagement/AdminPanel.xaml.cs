using BusinessObjects.Models;
using DAOs.DTOs;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        private Customer _customer;

        private List<StackPanel> _customerPanels;
        private List<StackPanel> _roomPanels;
        private List<StackPanel> _roomTypePanels;
        private List<StackPanel> _reservationPanels;

        public AdminPanel()
        {
            InitializeComponent();
            InitializePanels();
        }

        private void InitializePanels()
        {
            _customerPanels = new List<StackPanel>
            {
                sp_CusList, sp_CusTitle, sp_CusPlaceholder, sp_CusUpdate
            };

            _roomPanels = new List<StackPanel>
            {
                sp_RoomList, sp_RoomTitle, sp_RoomPlaceholder, sp_RoomUpdate, sp_FcRoomInfo
            };

            _roomTypePanels = new List<StackPanel>
            {
                sp_RoomTypeList, sp_RoomTypeTitle, sp_RoomTypePlaceholder, sp_RoomTypeUpdate
            };

            _reservationPanels = new List<StackPanel>
            {
                sp_BookingReservationList, sp_BookingDetailList, sp_Reservations
            };
        }

        private void ShowPanel(StackPanel panel)
        {
            HideAllPanels();
            panel.Visibility = Visibility.Visible;
        }

        private void HideAllPanels()
        {
            foreach (var panel in _customerPanels.Concat(_roomPanels).Concat(_roomTypePanels).Concat(_reservationPanels))
            {
                panel.Visibility = Visibility.Collapsed;
            }
        }

        private void bt_Customers_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(sp_CusList);
            var customers = _repo.GetCustomers();
            lv_CusList.ItemsSource = customers;
        }

        private void bt_CusDetails_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(sp_CusTitle);
            sp_CusPlaceholder.Visibility = Visibility.Visible;

            var button = sender as Button;
            var customer = button?.DataContext as Customer;
            if (customer != null)
                _customer = customer;

            if (_customer != null)
            {
                PH_CustomerID.Content = _customer.CustomerId;
                PH_Fullname.Content = _customer.CustomerFullName;
                PH_Telephone.Content = _customer.Telephone;
                PH_Email.Content = _customer.EmailAddress;
                PH_Birthday.Content = _customer.CustomerBirthday;
                PH_Status.Content = _customer.CustomerStatus;
                PH_Password.Content = _customer.Password;
            }
        }

        private void bt_CusUpdate_Click(object sender, RoutedEventArgs e)
        {
            ToggleVisibility(sp_CusUpdate, sp_CusPlaceholder);
            lbl_CustomerID.Content = PH_CustomerID.Content;
            txtb_Fullname.Text = PH_Fullname.Content.ToString();
            txtb_Telephone.Text = PH_Telephone.Content.ToString();
            txtb_Email.Text = PH_Email.Content.ToString();
            txtb_Birthday.Text = PH_Birthday.Content.ToString();
            txtb_Status.Text = PH_Status.Content.ToString();
            txtb_Password.Text = PH_Password.Content.ToString();
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
            if (_repo.DeleteCus(_customer.CustomerId))
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
            ShowPanel(sp_FcRoomInfo);
        }

        private void bt_RoomInformation_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(sp_RoomList);
            var roominfos = _roomInfoRepo.GetAll();
            lv_RoomList.ItemsSource = roominfos;
        }

        private void bt_RoomDetails_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(sp_RoomTitle);
            sp_RoomPlaceholder.Visibility = Visibility.Visible;

            var button = sender as Button;
            var roominfo = button?.DataContext as RoomInfoDTO;
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

        private void bt_RoomUpdate_Click(object sender, RoutedEventArgs e)
        {
            ToggleVisibility(sp_RoomUpdate, sp_RoomPlaceholder);
            lbl_RoomID.Content = PH_RoomID.Content;
            txtb_RoomNumber.Text = PH_RoomNumber.Content.ToString();
            txtb_RoomDetailDescription.Text = PH_RoomDetailDescription.Content.ToString();
            txtb_RoomMaxCapacity.Text = PH_RoomMaxCapacity.Content.ToString();
            txtb_RoomType.Text = PH_RoomType.Content.ToString();
            txtb_RoomStatus.Text = PH_RoomStatus.Content.ToString();
            txtb_RoomPricePerDay.Text = PH_RoomPricePerDay.Content.ToString();
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
            ShowPanel(sp_RoomTypeTitle);
            sp_RoomTypePlaceholder.Visibility = Visibility.Visible;

            var button = sender as Button;
            var roomType = button?.DataContext as RoomType;
            if (roomType != null)
            {
                PH_RoomTypeID.Content = roomType.RoomTypeId;
                PH_RoomTypeName.Content = roomType.RoomTypeName;
                PH_TypeDescription.Content = roomType.TypeDescription;
                PH_TypeNote.Content = roomType.TypeNote;
            }
        }

        private void bt_RoomTypeUpdate_Click(object sender, RoutedEventArgs e)
        {
            ToggleVisibility(sp_RoomTypeUpdate, sp_RoomTypePlaceholder);
            lbl_RoomTypeID.Content = PH_RoomTypeID.Content;
            txtb_RoomTypeName.Text = PH_RoomTypeName.Content.ToString();
            txtb_TypeDescription.Text = PH_TypeDescription.Content.ToString();
            txtb_TypeNote.Text = PH_TypeNote.Content.ToString();
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
            ShowPanel(sp_RoomTypeList);
            var roomtypes = _roomTypeRepo.GetRoomTypes();
            lv_RoomTypeList.ItemsSource = roomtypes;
        }

        private void bt_Reservations_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(sp_Reservations);
        }

        private void bt_BookingReservation_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(sp_BookingReservationList);
            var bookingReservations = _bookReservationRepo.GetBookingReservationDTOs();
            lv_BookingReservationList.ItemsSource = bookingReservations;
        }

        private void bt_BookingReservationDetails_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(sp_BookingDetailList);
            bt_BookingDetailReturn.Visibility = Visibility.Visible;
            var button = sender as Button;
            var bookingReservation = button?.DataContext as BookingReservationDTO;
            if (bookingReservation != null)
            {
                var bookingDetails = _bookingDetailRepo.GetBookingDetailsByBookingId(bookingReservation.BookingReservationId);
                lv_BookingDetailList.ItemsSource = bookingDetails;
            }
        }

        private void bt_BookingDetailReturn_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(sp_BookingReservationList);
            var bookingReservations = _bookReservationRepo.GetBookingReservations();
            lv_BookingReservationList.ItemsSource = bookingReservations;
        }

        private void bt_BookingDetail_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(sp_BookingDetailList);
            var bookingDetails = _bookingDetailRepo.GetBookingDetails();
            lv_BookingDetailList.ItemsSource = bookingDetails;
            bt_BookingDetailReturn.Visibility = Visibility.Collapsed;
        }

        private void ToggleVisibility(UIElement elementToShow, UIElement elementToHide)
        {
            elementToShow.Visibility = elementToShow.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            elementToHide.Visibility = elementToHide.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void bt_Logout_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
