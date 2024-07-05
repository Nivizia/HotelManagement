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
    /// Interaction logic for Admin_Customer.xaml
    /// </summary>
    public partial class Admin_Customer : Window
    {
        private readonly ICustomerRepository _repo = new CustomerRepository();
        public Admin_Customer()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            var customers = _repo.GetCustomers();
            dgCustomers.ItemsSource = customers;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(tbCustomerFullName.Text) ||
                    string.IsNullOrWhiteSpace(tbTelephone.Text) ||
                    string.IsNullOrWhiteSpace(tbEmail.Text) ||
                    !DateOnly.TryParse(tbCustomerBirthDay.Text, out DateOnly birthDate))
                {
                    MessageBox.Show("Please fill all fields with valid data.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Create a new customer object
                var newCustomer = new Customer
                {
                    CustomerFullName = tbCustomerFullName.Text,
                    Telephone = tbTelephone.Text,
                    EmailAddress = tbEmail.Text,
                    CustomerBirthday = birthDate,
                    CustomerStatus = 1 // Default status
                };

                // Add the new customer
                _repo.AddCustomer(newCustomer);

                // Reload the customers to refresh the DataGrid
                LoadCustomers();
                MessageBox.Show("Customer added successfully.", "Add Customer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                // Update the selected customer with the values from the StackPanel
                selectedCustomer.CustomerFullName = tbCustomerFullName.Text;
                selectedCustomer.Telephone = tbTelephone.Text;
                selectedCustomer.EmailAddress = tbEmail.Text;

                if (DateOnly.TryParse(tbCustomerBirthDay.Text, out DateOnly birthDate))
                {
                    selectedCustomer.CustomerBirthday = birthDate;
                }
                else
                {
                    MessageBox.Show("Invalid birth date format. Please use yyyy-MM-dd format.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                bool isUpdated = _repo.UpdateCustomer(selectedCustomer);
                if (isUpdated)
                {
                    LoadCustomers();
                    MessageBox.Show("Customer updated successfully.", "Update Customer", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update customer.", "Update Customer", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.", "Update Customer", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    _repo.DeleteCus(selectedCustomer.CustomerId);
                    LoadCustomers();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Delete Customer", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Management managementWindow = new Management();
            managementWindow.Show();
            this.Close();
        }
        private void dgCustomers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                tbCustomerId.Text = selectedCustomer.CustomerId.ToString();
                tbEmail.Text = selectedCustomer.EmailAddress;
                tbCustomerFullName.Text = selectedCustomer.CustomerFullName;
                pbPassword.Password = selectedCustomer.Password;
                tbTelephone.Text = selectedCustomer.Telephone;
                tbCustomerBirthDay.Text = selectedCustomer.CustomerBirthday?.ToString("yyyy-MM-dd");
            }
        }
    }
}
