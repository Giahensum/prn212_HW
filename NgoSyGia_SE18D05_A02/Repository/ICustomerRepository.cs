using BusinessObject;

namespace Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer? GetCustomerById(int customerId);
        Customer? GetCustomerByEmail(string email);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        IEnumerable<Customer> SearchCustomers(string searchTerm);
    }
}
