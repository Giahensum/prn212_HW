using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services
{
    public enum UserRole
    {
        Admin,
        Customer
    }

    public class AuthenticationResult
    {
        public bool IsSuccess { get; set; }
        public UserRole Role { get; set; }
        public CustomerDto? Customer { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }


    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password);
        bool IsAdminAccount(string email, string password);
        bool IsValidEmail(string email);
        bool IsValidPassword(string password);
    }
}

