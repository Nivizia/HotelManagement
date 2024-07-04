using BusinessObjects.Models;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer? CheckLogin(string Email, string Password) => CustomerDao.CheckLogin(Email, Password);

        public Customer? GetCustomerById(int id) => CustomerDao.GetCustomerById(id);

        public bool UpdateCustomer(Customer updatedCustomer) => CustomerDao.UpdateCustomer(updatedCustomer);
    }
}
