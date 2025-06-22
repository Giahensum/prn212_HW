using DataAccessLayer.Models;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        protected override List<Customer> GetDbSet()
        {
            return _context.Customers;
        }

        protected override int GetEntityId(Customer entity)
        {
            return entity.CustomerID;
        }

        protected override void SetEntityId(Customer entity, int id)
        {
            entity.CustomerID = id;
        }

        public Customer GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return _dbSet.FirstOrDefault(c =>
                c.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                c.CustomerStatus == 1);
        }

        public Customer Authenticate(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            return _dbSet.FirstOrDefault(c =>
                c.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                c.Password == password &&
                c.CustomerStatus == 1);
        }

        public IEnumerable<Customer> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return GetActiveCustomers();

            return _dbSet.Where(c =>
                c.CustomerFullName.Contains(name, StringComparison.OrdinalIgnoreCase) &&
                c.CustomerStatus == 1).ToList();
        }

        public IEnumerable<Customer> GetActiveCustomers()
        {
            return _dbSet.Where(c => c.CustomerStatus == 1).ToList();
        }

        public override void Delete(Customer entity)
        {
            // Soft delete - chỉ thay đổi status thay vì xóa thật
            if (entity != null)
            {
                entity.CustomerStatus = 2; // 2 = Deleted
                Update(entity);
            }
        }

        public override void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                Delete(customer);
            }
        }
    }
}
