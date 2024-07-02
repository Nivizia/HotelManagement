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
        public Customer? CheckLogin (string Email, string password);
    }
}
