using BusinessObject;
using DataAccess;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomers() => CustomerDAO.Instance.GetCustomers();

        public Customer? GetCustomerById(int customerId) => CustomerDAO.Instance.GetCustomerById(customerId);

        public Customer? GetCustomerByEmail(string email) => CustomerDAO.Instance.GetCustomerByEmail(email);

        public void AddCustomer(Customer customer) => CustomerDAO.Instance.AddCustomer(customer);

        public void UpdateCustomer(Customer customer) => CustomerDAO.Instance.UpdateCustomer(customer);

        public void DeleteCustomer(Customer customer) => CustomerDAO.Instance.DeleteCustomer(customer);

        public IEnumerable<Customer> SearchCustomers(string searchTerm) => CustomerDAO.Instance.SearchCustomers(searchTerm);
    }
}
