using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Extensions;
using DataAccessLayer.Repositories;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public CustomerDto Authenticate(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            var customer = _customerRepository.Authenticate(email, password);
            return customer?.ToDto();
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            return _customerRepository.GetAll().Select(c => c.ToDto());
        }

        public CustomerDto GetCustomerById(int id)
        {
            if (id <= 0) return null;

            var customer = _customerRepository.GetById(id);
            return customer?.ToDto();
        }

        public CustomerDto GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;

            var customer = _customerRepository.GetByEmail(email);
            return customer?.ToDto();
        }

        public void CreateCustomer(CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));

            if (!ValidateCustomer(customerDto, out List<string> errors))
                throw new ValidationException(string.Join("; ", errors));

            if (IsEmailExists(customerDto.EmailAddress))
                throw new InvalidOperationException("Email already exists");

            customerDto.CustomerID = 0; // Will be auto-generated
            customerDto.CustomerStatus = 1; // Active

            var customer = customerDto.ToEntity();
            _customerRepository.Add(customer);
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));

            if (!ValidateCustomer(customerDto, out List<string> errors))
                throw new ValidationException(string.Join("; ", errors));

            if (IsEmailExists(customerDto.EmailAddress, customerDto.CustomerID))
                throw new InvalidOperationException("Email already exists");

            var customer = customerDto.ToEntity();
            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid customer ID");

            _customerRepository.Delete(id);
        }

        public IEnumerable<CustomerDto> SearchCustomers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetActiveCustomers();

            return _customerRepository.SearchByName(searchTerm).Select(c => c.ToDto());
        }

        public IEnumerable<CustomerDto> GetActiveCustomers()
        {
            return _customerRepository.GetActiveCustomers()
                .OrderByDescending(c => c.CustomerID)
                .Select(c => c.ToDto());
        }

        public bool IsEmailExists(string email, int excludeCustomerId = 0)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            var existingCustomer = _customerRepository.GetByEmail(email);
            return existingCustomer != null && existingCustomer.CustomerID != excludeCustomerId;
        }

        public bool ValidateCustomer(CustomerDto customer, out List<string> errors)
        {
            errors = new List<string>();

            if (customer == null)
            {
                errors.Add("Customer data is required");
                return false;
            }

            // Validate using Data Annotations
            var validationContext = new ValidationContext(customer);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(customer, validationContext, validationResults, true))
            {
                errors.AddRange(validationResults.Where(vr => vr.ErrorMessage != null).Select(vr => vr.ErrorMessage!));
            }

            // Additional business rules
            if (customer.CustomerBirthday > DateTime.Now.AddYears(-18))
            {
                errors.Add("Customer must be at least 18 years old");
            }

            if (customer.CustomerBirthday < DateTime.Now.AddYears(-120))
            {
                errors.Add("Invalid birth date");
            }

            return errors.Count == 0;
        }

    }
}

