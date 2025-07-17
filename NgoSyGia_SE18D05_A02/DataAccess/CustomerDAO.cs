using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CustomerDAO
    {
        private static CustomerDAO? instance = null; // Fix: Make nullable
        private static readonly object instanceLock = new object();

        private CustomerDAO() { }

        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new CustomerDAO(); // Fix: Use compound assignment
                    return instance;
                }
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = []; // Fix: Simplified collection initialization
            try
            {
                using var context = new FUMiniHotelManagementContext();
                customers = context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        public Customer? GetCustomerById(int customerId) // Fix: Make return type nullable
        {
            Customer? customer = null;
            try
            {
                using var context = new FUMiniHotelManagementContext();
                customer = context.Customers.FirstOrDefault(c => c.CustomerID == customerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public Customer? GetCustomerByEmail(string email) // Fix: Make return type nullable
        {
            Customer? customer = null;
            try
            {
                using var context = new FUMiniHotelManagementContext();
                customer = context.Customers.FirstOrDefault(c => c.EmailAddress == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                context.Entry(customer).State = EntityState.Modified; // Fix: Removed generic type
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                var c1 = context.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
                if (c1 != null)
                {
                    context.Customers.Remove(c1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Customer> SearchCustomers(string searchTerm)
        {
            List<Customer> customers = []; // Fix: Simplified collection initialization
            try
            {
                using var context = new FUMiniHotelManagementContext();
                customers = context.Customers
                    .Where(c => (c.CustomerFullName != null && c.CustomerFullName.Contains(searchTerm)) ||
                               c.EmailAddress.Contains(searchTerm) ||
                               (c.Telephone != null && c.Telephone.Contains(searchTerm)))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }
    }
}
