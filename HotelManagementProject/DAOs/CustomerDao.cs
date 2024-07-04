using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class CustomerDao
    {
        public static Customer? CheckLogin(string Email, string Password)
        {
            using FuminiHotelManagementContext _context = new FuminiHotelManagementContext();
            var customer = _context.Customers
                .SingleOrDefault(c => c.EmailAddress.Equals(Email) && c.Password.Equals(Password));
            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public static Customer? GetCustomerById(int id)
        {
            using FuminiHotelManagementContext _context = new FuminiHotelManagementContext();
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }
        
        public static bool UpdateCustomer(Customer updatedCustomer)
        {
            try
            {
                using FuminiHotelManagementContext _context = new FuminiHotelManagementContext();
                var customer = _context.Customers
                    .SingleOrDefault(c => c.CustomerId.Equals(updatedCustomer.CustomerId));
                if (customer == null)
                {
                    return false;
                }
                customer.CustomerFullName = updatedCustomer.CustomerFullName;
                customer.Telephone = updatedCustomer.Telephone;
                customer.EmailAddress = updatedCustomer.EmailAddress;
                customer.CustomerBirthday = updatedCustomer.CustomerBirthday;

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DAOs/CustomerDao.cs -> UpdateCustomer(Customer updatedCustomer): {ex.Message}");
                return false;
            }
        }
    }
}
