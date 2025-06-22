using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
        Customer Authenticate(string email, string password);
        IEnumerable<Customer> SearchByName(string name);
        IEnumerable<Customer> GetActiveCustomers();
    }
}

