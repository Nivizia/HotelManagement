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
            var customer = _context.Customers.SingleOrDefault(c => c.EmailAddress.Equals(Email) && c.Password.Equals(Password));
            if (customer == null)
            {
                return null;
            }
            return customer;
        }
    }
}
