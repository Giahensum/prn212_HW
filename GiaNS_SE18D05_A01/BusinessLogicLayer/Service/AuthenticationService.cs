using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogicLayer.DTOs;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using System.Text.RegularExpressions;
using BusinessLogicLayer.Extensions;

namespace BusinessLogicLayer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly HotelDbContext _context;

        public AuthenticationService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _context = HotelDbContext.Instance;
        }

        public AuthenticationResult Login(string email, string password)
        {
            var result = new AuthenticationResult();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                result.ErrorMessage = "Email and password are required";
                return result;
            }

            // Check admin account first
            if (IsAdminAccount(email, password))
            {
                result.IsSuccess = true;
                result.Role = UserRole.Admin;
                return result;
            }

            // Check customer account
            var customer = _customerRepository.Authenticate(email, password);
            if (customer != null)
            {
                result.IsSuccess = true;
                result.Role = UserRole.Customer;
                result.Customer = customer.ToDto();
                return result;
            }

            result.ErrorMessage = "Invalid email or password";
            return result;
        }

        public bool IsAdminAccount(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return false;

            return email.Equals(_context.AdminAccount.EmailAddress, StringComparison.OrdinalIgnoreCase) &&
                   password == _context.AdminAccount.Password;
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return emailRegex.IsMatch(email) && email.Length <= 50;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) &&
                   password.Length >= 6 &&
                   password.Length <= 50;
        }
    }
}

