using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services
{
    public interface ICustomerService
    {
        // Authentication
        CustomerDto Authenticate(string email, string password);

        // CRUD operations
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(int id);
        CustomerDto GetCustomerByEmail(string email);
        void CreateCustomer(CustomerDto customer);
        void UpdateCustomer(CustomerDto customer);
        void DeleteCustomer(int id);

        // Search and filter
        IEnumerable<CustomerDto> SearchCustomers(string searchTerm);
        IEnumerable<CustomerDto> GetActiveCustomers();

        // Validation
        bool IsEmailExists(string email, int excludeCustomerId = 0);
        bool ValidateCustomer(CustomerDto customer, out List<string> errors);
    }
}

