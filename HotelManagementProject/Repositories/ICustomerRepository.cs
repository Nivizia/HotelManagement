using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
namespace Repositories
{
    public interface ICustomerRepository
    {
        public Customer? CheckLogin(string Email, string password);

        public Customer? GetCustomerById(int id);

        public bool UpdateCustomer(Customer updatedCustomer);

        public void AddCustomer(Customer newCustomer);

        public List<Customer> GetCustomers();

        public bool DeleteCus(int customerId);
    }
}
